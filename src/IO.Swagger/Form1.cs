using IO.TVSeries;
using IO.TVSeries.ds1TableAdapters;
using IO.TVSeries.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IO.TVSeries
{
    public partial class Form1 : Form
    {
        private const string apiKey = "     ";
        string apiKeyManual = "";
        System.Globalization.CultureInfo cultureUS = new System.Globalization.CultureInfo("en-us");
        System.Globalization.CultureInfo cultureGR = new System.Globalization.CultureInfo("el-gr");
        private const string baseUrl = "https://imdb-api.com/el/API/";
        HttpClient client;
        private Button btnSeries1;
        private RichTextBox rtbConsole1;
        private Button btnPopularTV;
        private Button BtnAdvanceSearch;
        private Button btnSeasonEp;
        private TextBox tbSeasonEp;
        private GroupBox groupBoxSeasonEp;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private Label label1;
        private NumericUpDown numUpDownSeasons;
        private NumericUpDown numUpDays;
        string responseData_ = "";
        private Button btnScanSeries;
        private CheckBox cbARFetch;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private CheckBox cbStep2;
        private TextBox tbApiKey;
        private Label label9;
        String masterConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=IMDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            rtbConsole1.EnableContextMenu();
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string dateFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string dateTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }

        private void btnSeries1_Click(object sender, EventArgs e)
        {
            string apiCall = "Search";
            string expression = "all";
            apiKeyManual = tbApiKey.Text.Trim();

            Task<string> taskA = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));

            taskA.Wait();
            string responseData_ = taskA.Result;

            rtbConsole1.Text = responseData_;

            try
            {

                var deserializedResponse = JsonConvert.DeserializeObject<IO.TVSeries.Model.SearchData>(responseData_);
                var returnResults = deserializedResponse;

                if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                {
                    rtbConsole1.Text = "errorMessage: " + returnResults.ErrorMessage + Environment.NewLine;
                }
                else
                {
                    rtbConsole1.AppendText(returnResults.Results + Environment.NewLine + Environment.NewLine);

                    if (returnResults.Results != null)
                    {
                        foreach (var item in returnResults.Results)
                        {
                            rtbConsole1.AppendText(item.Id + " | " + item.ResultType + " | " + item.Title + " | " + item.Description + Environment.NewLine);
                        }

                        rtbConsole1.AppendText("count: " + returnResults.Results.Count() + Environment.NewLine);
                    }


                }
            }
            catch (Exception ex)
            {
                rtbConsole1.AppendText("exception errorMessage: " + ex.Message);
            }


        }

        private void btnPopularTV_Click(object sender, EventArgs e)
        {
            apiKeyManual = tbApiKey.Text.Trim();
            string responseData_ = null;
            string apiCall = "Top250TVs";
            string expression = "";
            Task<string> taskA = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));
            taskA.Wait();
            responseData_ = taskA.Result;

            //rtbConsole1.Text = Configuration.ToDebugReport() + Environment.NewLine;
            //rtbConsole1.Text += responseData_ + Environment.NewLine; ;
            try
            {

                var deserializedResponse = JsonConvert.DeserializeObject<Model.Top250Data>(responseData_);
                var returnResults = deserializedResponse;
                //txtResult.Text = returnResults.results.title.ToString();

                if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                {
                    rtbConsole1.Text = "errorMessage: " + returnResults.ErrorMessage + Environment.NewLine;
                }
                else
                {
                    //rtbConsole1.Text += Configuration.ToDebugReport() + Environment.NewLine;
                    //rtbConsole1.Text += returnResults.Items + Environment.NewLine + Environment.NewLine;

                    if (returnResults.Items != null)
                    {
                        foreach (var item in returnResults.Items)
                        {
                            rtbConsole1.Text += item.Id + " | " + item.Rank + " | " + item.Title + " | " + item.FullTitle + " | " +
                                item.ImDbRating + " | " + item.ImDbRatingCount + " | " + item.Year +
                                Environment.NewLine;
                        }

                        rtbConsole1.Text += "count: " + returnResults.Items.Count() + Environment.NewLine;
                    }


                }
            }
            catch (Exception ex)
            {
                rtbConsole1.Text = "exception errorMessage: " + ex.Message;
            }
        }

        private void BtnAdvanceSearch_Click(object sender, EventArgs e)
        {
            rtbConsole1.Text = "";
            apiKeyManual = tbApiKey.Text.Trim();
            DateTime dateFromD = dateTimePicker1.Value;
            DateTime dateToD = dateTimePicker2.Value;
            int addedDays = (int)numUpDays.Value;
            string dateFrom, dateTo = null;
            StringBuilder sql = new StringBuilder();
            StringBuilder output = new StringBuilder();
            String separator = ";";
            String[] headings = { "Id", "Title", "Description", "Genres", "RuntimeStr", "IMDbRating", "IMDbRatingVotes" };
            output.AppendLine(string.Join(separator, headings));

            if (dateFromD > dateToD)
            {
                rtbConsole1.Text = "Λάθος ημερομηνία έναρξης, λήξης";
                Environment.ExitCode = 0;
            }
            //
            // Create a DataTable imdbSeries.
            //
            DataTable imdbSeries = new DataTable();
            imdbSeries.Columns.Add("Id", typeof(string));
            imdbSeries.Columns.Add("Title", typeof(string));
            imdbSeries.Columns.Add("Description", typeof(string));
            imdbSeries.Columns.Add("Genres", typeof(string));
            imdbSeries.Columns.Add("RuntimeStr", typeof(string));
            imdbSeries.Columns.Add("IMDbRating", typeof(int));
            imdbSeries.Columns.Add("IMDbRatingVotes", typeof(int));
            imdbSeries.Columns.Add("Status", typeof(short));

            //
            // Create new SqlConnection, SqlDataAdapter, and builder.
            //
            using (var con = new SqlConnection(masterConnectionString))
            using (var adapter = new SqlDataAdapter("SELECT * FROM [dbo].[IMDbSeries]", con))
            using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
            {
                SqlParameter parameter = new SqlParameter("@fileSize", SqlDbType.Decimal);
                parameter.Scale = 2;
                adapter.GetFillParameters();
                con.Open();

                while (dateFromD < dateToD)
                {
                    dateFrom = dateFromD.ToString("yyyy-MM-dd");
                    dateTo = dateTimePicker2.Value > dateFromD.AddDays(addedDays) ? dateFromD.AddDays(addedDays).ToString("yyyy-MM-dd") : dateTimePicker2.Value.ToString("yyyy-MM-dd");

                    responseData_ = null;
                    string apiCall = "AdvancedSearch";
                    string expression = $"?title_type=tv_series&user_rating=1.0,&release_date={dateFrom},{dateTo}&num_votes=100,&count=250"; //&sort=user_rating,asc";
                                                                                                                                             //string expression = "?title_type=tv_series,tv_episode,tv_miniseries,tv_short&release_date=2020-01-01,2020-12-31&countries=gr&count=250&sort=release_date,asc";
                    Task<string> taskA = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));
                    taskA.Wait();
                    responseData_ = taskA.Result;

                    try
                    {
                        var deserializedResponse = JsonConvert.DeserializeObject<AdvancedSearchData>(responseData_);
                        var returnResults = deserializedResponse;

                        if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                        {
                            rtbConsole1.AppendText("errorMessage: " + returnResults.ErrorMessage + Environment.NewLine);
                        }
                        else
                        {
                            if (returnResults.Results != null || returnResults.Results.Count > 0)
                            {
                                foreach (var item in returnResults.Results)
                                {
                                    try
                                    {
                                        //rtbConsole1.Text += item.Id + ";" + item.Title + ";" + item.Description + ";" + item.Genres + ";" + item.RuntimeStr + //" | " +
                                        //    ";" + item.IMDbRating + ";" + item.IMDbRatingVotes + //" | " + item.Plot + //" | " + item.Stars +
                                        //    Environment.NewLine;

                                        String iMBDRating = !String.IsNullOrEmpty(item.IMDbRating) ? item.IMDbRating.Trim() : "0";   // Ας κάνουμε έλεγχο. Για να μην σκάσει μετά η μετατροπή σε αριθμό
                                        String iMBDRatingCount = !String.IsNullOrEmpty(item.IMDbRatingVotes) ? item.IMDbRatingVotes.Trim() : "0";  // Ομοίως
                                        AddIMDbSeriesRow(imdbSeries, item.Id, item.Title, item.Description, item.Genres, item.RuntimeStr, Decimal.Parse(iMBDRating, CultureInfo.InvariantCulture), Int32.Parse(iMBDRatingCount));
                                        adapter.Update(imdbSeries);                                                                                //Ενημέρωση datatable
                                        String[] strNewLine = { item.Id, item.Title, item.Description, item.Genres, item.RuntimeStr, item.IMDbRating, item.IMDbRatingVotes };
                                        output.AppendLine(string.Join(separator, strNewLine));
                                    }
                                    catch (Exception ex)
                                    {
                                        //rtbConsole1.Text += adapter.Update(imdbSeries) + " records was inserted , ";
                                        RemoveIMDbSeriesRow(imdbSeries, item.Id);                 // Αφαιρεί την τελευταία γραμμή από το datatable που δημιούργησε το exception error
                                        rtbConsole1.AppendText("exception errorMessage: " + ex.Message + Environment.NewLine);
                                    }
                                }
                            }

                            rtbConsole1.Text = output.ToString();

                            int counterRes = returnResults.Results.Count();
                            //  Το ερώτημα μπορεί να επιστρέψει μέχρι 250 σειρές σε κάθε ερώτημα.
                            //  Εμφανίζει μήνυμα όταν φέρει 250 σειρές για την επιλεγμένη περίοδο. Αυτό σημαίνει ότι υπάρχουν και άλλες που δεν έφερε.
                            //  Πρέπει να επιλέξουμε μικρότερη περίοδο ώστε να μην χάσουμε τις σειρές που δεν έφερε.
                            if (counterRes > 249)
                            {
                                rtbConsole1.AppendText("Error: Return more than 250 records for period " + dateFrom + " - " + dateTo + Environment.NewLine);
                                rtbConsole1.AppendText("Επέλεξε μικρότερη περίοδο" + Environment.NewLine);
                                //con.Close();
                                return;
                            }
                            else
                            {
                                //con.Close();
                                rtbConsole1.AppendText("count: " + returnResults.Results.Count() + " | " + dateFrom + " - " + dateTo + Environment.NewLine);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        rtbConsole1.AppendText("exception errorMessage: " + ex.Message + Environment.NewLine);
                        break;
                    }
                    finally
                    {
                        con.Close();
                        dateFromD = dateFromD.AddDays(addedDays + 1);
                        Thread.Sleep(millisecondsTimeout: 1 * 1000);
                    }
                }
                con.Dispose();
                output.Clear();
                rtbConsole1.AppendText("Message: Save Completed" + Environment.NewLine);
            }
        }

        private void btnScanSeries_Click(object sender, EventArgs e)
        {
            rtbConsole1.Text = "";
            apiKeyManual = tbApiKey.Text.Trim();
            string serieId = tbSeasonEp.Text.Trim();
            string sDESCR = "", realeaseDate = "", awards = "", plot = "", plotLocal = "";
            cbStep2.Visible = false;
            int seasonsMax = 0, i = 0; ;
            List<string> SeasonList = new List<string>();

            TableAdapterManager mgr1 = new TableAdapterManager();
            IMDbSeriesTableAdapter sqlAdapter1 = new IMDbSeriesTableAdapter();
            IMDbSeriesInfoTableAdapter sqlAdapter2 = new IMDbSeriesInfoTableAdapter();
            using (mgr1.IMDbSeriesTableAdapter = sqlAdapter1)
            using (mgr1.IMDbSeriesInfoTableAdapter = sqlAdapter2)
            {
                DataSet ds1 = new ds1();
                mgr1.IMDbSeriesTableAdapter.Fill((ds1.IMDbSeriesDataTable)ds1.Tables[1]);
                mgr1.IMDbSeriesInfoTableAdapter.Fill((ds1.IMDbSeriesInfoDataTable)ds1.Tables[0]);
                mgr1.UpdateOrder = TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

                foreach (DataRow row1 in ds1.Tables[1].Select("status is null", "IMDbRating DESC").Distinct())  // IMDbSeries  DataRow row = table.Select("Status is null").FirstOrDefault();
                {
                    if (++i > 1500) break;
                    serieId = String.Format("{0}", row1["id"]);
                    sDESCR = String.Format("{0}", row1["Description"]);
                    responseData_ = null;
                    string apiCall = "Title";
                    string expression = serieId;
                    Task<string> taskA = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));
                    taskA.Wait();
                    responseData_ = taskA.Result;

                    try
                    {
                        var deserializedResponse = JsonConvert.DeserializeObject<TitleData>(responseData_);
                        var returnResults = deserializedResponse;

                        if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                        {
                            rtbConsole1.Text += "errorMessage: " + returnResults.ErrorMessage + Environment.NewLine;
                            if (returnResults.ErrorMessage == "Year is empty")    // Είναι από τις νέες σειρές και δεν έχουν πλήρη στοιχεία
                            {
                                rtbConsole1.AppendText(serieId + " Δεν υπάρχουν εγγραφές για season.");

                                row1.SetField("status", "2");  // Ενημερώνει τον IMDBSeries με 2 όταν δεν βρίσκει το στοιχεία με season  
                                continue;
                            }
                            break;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(returnResults.TvSeriesInfo.ToString())) //LastOrDefault()))
                            {
                                SeasonList.Add("0");
                                foreach (var item in returnResults.TvSeriesInfo.Seasons)
                                //  Δεν σώζουμε όλα τα records. ’λωστε το μόνο που αλλάζει είναι ο # κύκλου. Κρατάω μόνο τον τελευταίο. 
                                {
                                    SeasonList.Add(item);
                                    seasonsMax = Convert.ToInt32(SeasonList.LastOrDefault());  // Are sorted ASC by default, we keep the max
                                }
                                realeaseDate = returnResults.ReleaseDate;
                                awards = returnResults.Awards;
                                plot = returnResults.Plot;
                                plotLocal = returnResults.PlotLocal;
                                rtbConsole1.AppendText(serieId + " | " + seasonsMax + " | " + realeaseDate + " | " + awards + " | " + plot + " | " + plotLocal + Environment.NewLine);
                                ds1.Tables[0].Rows.Add(serieId, seasonsMax, realeaseDate, awards, plot, plotLocal, null, System.DateTime.Now.Date);
                                SeasonList.Clear();
                            }
                            row1.SetField("status", "1");   // ενημερώνει στον series ότι έχει την πληροφορία στον info
                        }
                    }
                    catch (Exception ex)
                    {
                        rtbConsole1.Text += "exception errorMessage: " + ex.Message;
                    }
                    //Thread.Sleep(millisecondsTimeout: 250);
                }
                mgr1.IMDbSeriesInfoTableAdapter.Update((ds1.IMDbSeriesInfoDataTable)ds1.Tables[0]);
                rtbConsole1.Text += mgr1.IMDbSeriesTableAdapter.Update((ds1.IMDbSeriesDataTable)ds1.Tables[1]);
                sqlAdapter1.Dispose();
                sqlAdapter2.Dispose();
                mgr1.IMDbSeriesTableAdapter.Dispose();
                cbStep2.Visible = true;                     // Ένδειξη ότι τελείωσε η διαδικασία
            }
        }

        private void btnSeasonEp_Click(object sender, EventArgs e)
        {
            String serieId = tbSeasonEp.Text.Trim();
            apiKeyManual = tbApiKey.Text.Trim();
            int season = ((int)numUpDownSeasons.Value);
            rtbConsole1.Clear();
            rtbConsole1.Text = "";
            responseData_ = null;
            String apiCall = "SeasonEpisodes";
            String expression = $"{serieId}/{season}";
            String sDESCR = "", seasonFetched = "", realeaseDate = "", lastupdate = "", plot = "", plotLocal = "";
            int releaseYear = 0;
            int seasonsMax = 1, lastSeasonRec = 1;

            if (cbARFetch.Checked)  // Based to IMDBSeries table retreives data from IMDB api for all series  
            {
                responseData_ = null;
                ds1TableAdapters.TableAdapterManager mgr1 = new ds1TableAdapters.TableAdapterManager();
                IMDbSeriesInfoTableAdapter sqlAdapter1 = new IMDbSeriesInfoTableAdapter();
                IMDbEpisodesTableAdapter sqlAdapter2 = new IMDbEpisodesTableAdapter();
                using (mgr1.IMDbSeriesInfoTableAdapter = sqlAdapter1)
                using (mgr1.IMDbEpisodesTableAdapter = sqlAdapter2)
                {
                    DataSet ds1 = new ds1();
                    sqlAdapter1.Fill((ds1.IMDbSeriesInfoDataTable)ds1.Tables[0]);
                    sqlAdapter2.Fill((ds1.IMDbEpisodesDataTable)ds1.Tables[2]);
                    mgr1.UpdateOrder = TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
                    ds1.Tables[0].TableName = "IMDbSeriesInfo";
                    ds1.Tables[2].TableName = "IMDbEpisodes";
                    int i = 0;

                    foreach (DataTable dt in ds1.Tables)
                    {
                        if (dt.TableName == "IMDbSeriesInfo")
                        {
                            try
                            {
                            SerieFetch:    //SeasonFetched : 1=All seasons saved , 100=No data returned for the serie/season
                                           // Το ακόλουθο query χρησιμοποιήται για να μην ζητά σειρές που στο season δεν έχουν κύκλους αλλά χρονιές.
                                           // Με το sort πετυχαίνουμε να ξεκινά από εκεί που σταμάτησε η τελευταία αναζήτηση.
                                foreach (DataRow row in dt.Select("Seasons > 0 AND SeasonFetched is NULL", "Seasons DESC, Id"))
                                {
                                    if (++i > 1000) break;              // Για να μην δουλευει μέχρι δευτέρας παρουσίας
                                    if (row is null) return;            // Αν δεν έχει κάτι για να ψαξει, stop
                                    serieId = String.Format("{0}", row["id"]).Trim();
                                    if (!String.IsNullOrEmpty(row["Seasons"].ToString().Trim()))     // Το άνω όριο επαναλήψεων στο Season Loop  (βλέπε πιο κάτω)
                                    {
                                        seasonsMax = Convert.ToInt32(row["Seasons"].ToString());
                                        if (seasonsMax > 2000)
                                        {
                                            lastSeasonRec = !String.IsNullOrEmpty(row["ReleaseDate"].ToString().Trim()) ? Convert.ToDateTime(row["ReleaseDate"]).Year : 0;
                                        }
                                    }
                                    else
                                    {
                                        seasonsMax = 0;
                                    }

                                    releaseYear = !String.IsNullOrEmpty(row["ReleaseDate"].ToString().Trim()) ? Convert.ToDateTime(row["ReleaseDate"]).Year : 0;

                                    seasonFetched = String.Format("{0}", row["SeasonFetched"]);

                                    // Για την περίπτωση που δεν έχουν αποθηκευτεί στη βάση όλες οι season τις σειράς 
                                    // Από τον πίνακα info φέρνει την τελευταία season που έχει για τη σειρά, για να καλέσει από αυτή και μετά.
                                    string query = string.Format("IMDbId = '{0}'", serieId).Replace(",", "SeasonNumber DESC");  // Δημιουργία του query
                                    DataRow rowTB2 = ds1.Tables[2].Select(query).FirstOrDefault();
                                    if (rowTB2 != null && lastSeasonRec < 2000) lastSeasonRec = Convert.ToInt32(rowTB2["SeasonNumber"].ToString());  // και τη σώζει στην lastSeasonRec

                                    // ΠΡΟΣΟΧΗ -> Αν επιλέξω season στο UI, ελέγχει από αυτόν τον κύκλο και μετά.
                                    season = (lastSeasonRec > 0 && season < lastSeasonRec) ? lastSeasonRec : season;

                                    //  Season loop         Ζητάει από το api 1 προς 1 τις season της σειράς με αρχή την lastSeasonRec
                                    for (int seasonCount = season; seasonCount <= seasonsMax; seasonCount++)
                                    {
                                        expression = $"{serieId}/{seasonCount}";                    // Συνθέτει το expression για την κλήση
                                        Task<string> taskB = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));   // Ενεργοποιεί το task για την διαδικασία κλήσης του api
                                        taskB.Wait();
                                        responseData_ = taskB.Result;
                                        lastSeasonRec = 0;
                                        try
                                        {
                                            var deserializedResponse = JsonConvert.DeserializeObject<SeasonEpisodeData>(responseData_);      //   JSON deserialization
                                            var returnResults = deserializedResponse;
                                            //Thread.Sleep(millisecondsTimeout: 450);       //  Δεν χρειάζεται timeout

                                            // Αν κάτι στράβωσε
                                            if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                                            {
                                                rtbConsole1.AppendText("errorMessage: " + returnResults.ErrorMessage + Environment.NewLine);

                                                // Αν δεν έχει στοιχεία επεισοδίων για τη season η IMDB πάει στην επόμενη season
                                                if (returnResults.ErrorMessage == "404 Not Founded Error")
                                                {
                                                    rtbConsole1.AppendText(serieId + " -- Δεν υπάρχουν δεδομένα για τον κύκλο " + seasonCount + Environment.NewLine);
                                                    continue;
                                                }

                                                // Για τη σειρά που το API δεν έχει στοιχεία για το season, την παρακάμπτουμε και πάμε για άλλη.
                                                if (returnResults.ErrorMessage == "Server busy")
                                                {
                                                    row.SetField("SeasonFetched", 100);                     // Ενημερώνει τον info ότι υπάρχει θέμα για να μη την ξαναψάξει
                                                    row.SetField("Lastupdate", System.DateTime.Now.Date);   // Ας κρατήσουμε το πότε 
                                                    sqlAdapter1.Update((ds1.IMDbSeriesInfoDataTable)ds1.Tables[0]);
                                                    goto SerieFetch;                                        // Στέλνει την εκτέλεση πάνω για αναζήτηση επόμενης σειράς
                                                }

                                                Environment.ExitCode = 0;
                                                return;
                                            }
                                            // Αν δεν στράβωσε, προχωράει για εισαγωγή στοιχείων στον episode
                                            else
                                            {
                                                //  Αν δεν έχεις εμπιστοσύνη στα error code του api
                                                if (returnResults.Episodes != null)
                                                {
                                                    //  για την εργασία θέλω μόνο τα στοιχεία των επεισοδίων
                                                    foreach (var item in returnResults.Episodes)
                                                    {
                                                        try
                                                        {
                                                            String iMBDRating = !String.IsNullOrEmpty(item.ImDbRating) ? item.ImDbRating.Trim() : "0";   // Ας κάνουμε έλεγχο. Για να μην σκάσει μετά η μετατροπή σε αριθμό
                                                            String iMBDRatingCount = !String.IsNullOrEmpty(item.ImDbRatingCount) ? item.ImDbRatingCount.Trim() : "0";  // Ομοίως
                                                            String seaNum = !String.IsNullOrEmpty(item.SeasonNumber) ? item.SeasonNumber.Trim() : "0";  // Ομοίως
                                                            String epiNum = !String.IsNullOrEmpty(item.EpisodeNumber) ? item.EpisodeNumber.Trim() : "0";  // Ομοίως
                                                            // Για να βλέπουμε στην κονσόλα κάποιες πληροφορίες
                                                            rtbConsole1.AppendText(returnResults.ImDbId + " | " + item.Id + " | " + " | " + item.SeasonNumber + " | " + item.EpisodeNumber + " | " + item.Title + " | " + " | " + item.Year + " | " + item.ImDbRating + " | " + item.ImDbRatingCount + Environment.NewLine);
                                                            // Απευθείας εισαγωγή των στοιχείων στον episode
                                                            sqlAdapter2.Insert(item.Id.Trim(), Convert.ToInt16(seaNum), Convert.ToInt32(epiNum), item.Title, item.Image, Convert.ToInt32(item.Year), item.Released, item.Plot, Decimal.Parse(iMBDRating, CultureInfo.InvariantCulture), Convert.ToInt32(iMBDRatingCount), serieId, DateTime.Now.Date);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            //  Αν υπάρχει ήδη το επεισόδιο...
                                                            if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                                                            {
                                                                //  πάει για το επόμενο της season
                                                                continue;
                                                            }
                                                        }

                                                    }
                                                    //rtbConsole1.Text += "count: " + returnResults.Episodes.Count() + Environment.NewLine;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            rtbConsole1.AppendText("exception errorMessage: " + ex.Message);
                                        }
                                    }
                                    //  Αφού έσωσε για όλες τις season της σειράς
                                    //  ενημερώνει τον info για το καλώς έχει.
                                    row.SetField("SeasonFetched", 1);
                                    row.SetField("Lastupdate", System.DateTime.Now.Date);
                                    sqlAdapter1.Update((ds1.IMDbSeriesInfoDataTable)ds1.Tables[0]);
                                    rtbConsole1.AppendText("ID: " + serieId + " - Seasons : " + seasonsMax + "---  " + seasonFetched + ",  " + lastupdate + Environment.NewLine);
                                }
                            }
                            catch (Exception ex)
                            {
                                rtbConsole1.AppendText("exception errorMessage: " + ex.Message);
                            }
                        }
                    }
                }
                rtbConsole1.AppendText("Message: Save Completed" + Environment.NewLine);
            }
            //  Αν το checkbox είναι unchecked απλά φέρνει τα επεισόδια της σειράς/season για να τα δούμε - ελέγξουμε.
            //  Τα ακόλουθα τα είδαμε και ανωτέρω, αλλά δεν αποθηκεύει και δεν χρειάζεται να κάνει όλους τους ελέγχους.
            else
            {
                Task<string> taskA = Task<string>.Run(() => ProcessSearchAsync(client, apiCall, expression, apiKeyManual));
                rtbConsole1.Text = "";
                taskA.Wait();
                responseData_ = taskA.Result;

                try
                {
                    var deserializedResponse = JsonConvert.DeserializeObject<SeasonEpisodeData>(responseData_);
                    var returnResults = deserializedResponse;

                    if (!string.IsNullOrEmpty(returnResults.ErrorMessage))
                    {
                        rtbConsole1.Text = "errorMessage: " + returnResults.ErrorMessage + Environment.NewLine;
                    }
                    else
                    {
                        rtbConsole1.AppendText(returnResults.ImDbId + " | " + returnResults.Title + " | " + returnResults.Year + " | " + returnResults.Episodes + Environment.NewLine + Environment.NewLine);

                        if (returnResults.ErrorMessage != null)
                        {
                            foreach (var item in returnResults.Episodes)
                            {
                                rtbConsole1.AppendText(item.Id + " | " + " | " + item.SeasonNumber + " | " + item.EpisodeNumber + " | " + item.Title + " | " + " | " + item.Year + " | " + item.ImDbRating + " | " + item.ImDbRatingCount + Environment.NewLine);
                            }

                            rtbConsole1.AppendText("count: " + returnResults.Episodes.Count() + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    rtbConsole1.AppendText("exception errorMessage: " + ex.Message);
                }
            }
        }


        private static async Task<string> ProcessSearchAsync(HttpClient client, string apiCall, string expression, string apiKeyManual)
        {
            string apiKEy = String.IsNullOrWhiteSpace(apiKeyManual.Trim()) ? Form1.apiKey : apiKeyManual.Trim();
            var json = await client.GetStringAsync(
                client.BaseAddress.ToString() + $"{apiCall}/{apiKEy}/{expression}");

            return json;
        }

        /// <summary>
        /// for IMDbSeries table
        /// </summary>
        static DataRow AddIMDbSeriesRow(DataTable imdbSeries, string id, string title, string description, string genres, string runtimeStr, decimal iMDbRating, Int32 iMDbRatingVotes)
        {
            //
            // This method uses custom code to generate the size type.
            //
            return imdbSeries.Rows.Add(id, title, description, genres, runtimeStr, iMDbRating, iMDbRatingVotes);
        }

        static void RemoveIMDbSeriesRow(DataTable imdbSeries, string id1)
        {
            imdbSeries.Select("Id=id").ToList().ForEach(x => x.Delete());
            imdbSeries.AcceptChanges();
        }


        private void InitializeComponent()
        {
            this.btnSeries1 = new System.Windows.Forms.Button();
            this.rtbConsole1 = new System.Windows.Forms.RichTextBox();
            this.btnPopularTV = new System.Windows.Forms.Button();
            this.BtnAdvanceSearch = new System.Windows.Forms.Button();
            this.btnSeasonEp = new System.Windows.Forms.Button();
            this.tbSeasonEp = new System.Windows.Forms.TextBox();
            this.groupBoxSeasonEp = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownSeasons = new System.Windows.Forms.NumericUpDown();
            this.cbARFetch = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.numUpDays = new System.Windows.Forms.NumericUpDown();
            this.btnScanSeries = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStep2 = new System.Windows.Forms.CheckBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxSeasonEp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSeasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDays)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeries1
            // 
            this.btnSeries1.Location = new System.Drawing.Point(752, 13);
            this.btnSeries1.Name = "btnSeries1";
            this.btnSeries1.Size = new System.Drawing.Size(75, 23);
            this.btnSeries1.TabIndex = 0;
            this.btnSeries1.Text = "Series";
            this.btnSeries1.UseVisualStyleBackColor = true;
            this.btnSeries1.Click += new System.EventHandler(this.btnSeries1_Click);
            // 
            // rtbConsole1
            // 
            this.rtbConsole1.AcceptsTab = true;
            this.rtbConsole1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole1.AutoWordSelection = true;
            this.rtbConsole1.BulletIndent = 2;
            this.rtbConsole1.HideSelection = false;
            this.rtbConsole1.Location = new System.Drawing.Point(4, 112);
            this.rtbConsole1.Margin = new System.Windows.Forms.Padding(5);
            this.rtbConsole1.Name = "rtbConsole1";
            this.rtbConsole1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbConsole1.ShortcutsEnabled = false;
            this.rtbConsole1.ShowSelectionMargin = true;
            this.rtbConsole1.Size = new System.Drawing.Size(834, 235);
            this.rtbConsole1.TabIndex = 1;
            this.rtbConsole1.Text = this.rtbConsole1.Text;
            this.rtbConsole1.WordWrap = false;
            // 
            // btnPopularTV
            // 
            this.btnPopularTV.Location = new System.Drawing.Point(752, 47);
            this.btnPopularTV.Name = "btnPopularTV";
            this.btnPopularTV.Size = new System.Drawing.Size(75, 23);
            this.btnPopularTV.TabIndex = 2;
            this.btnPopularTV.Text = "Top TV";
            this.btnPopularTV.UseVisualStyleBackColor = true;
            this.btnPopularTV.Click += new System.EventHandler(this.btnPopularTV_Click);
            // 
            // BtnAdvanceSearch
            // 
            this.BtnAdvanceSearch.Location = new System.Drawing.Point(150, 78);
            this.BtnAdvanceSearch.Name = "BtnAdvanceSearch";
            this.BtnAdvanceSearch.Size = new System.Drawing.Size(85, 23);
            this.BtnAdvanceSearch.TabIndex = 4;
            this.BtnAdvanceSearch.Text = "Save Series";
            this.BtnAdvanceSearch.UseVisualStyleBackColor = true;
            this.BtnAdvanceSearch.Click += new System.EventHandler(this.BtnAdvanceSearch_Click);
            // 
            // btnSeasonEp
            // 
            this.btnSeasonEp.Location = new System.Drawing.Point(128, 45);
            this.btnSeasonEp.Name = "btnSeasonEp";
            this.btnSeasonEp.Size = new System.Drawing.Size(86, 22);
            this.btnSeasonEp.TabIndex = 5;
            this.btnSeasonEp.Text = "Episodes";
            this.btnSeasonEp.UseVisualStyleBackColor = true;
            this.btnSeasonEp.Click += new System.EventHandler(this.btnSeasonEp_Click);
            // 
            // tbSeasonEp
            // 
            this.tbSeasonEp.Location = new System.Drawing.Point(35, 19);
            this.tbSeasonEp.Name = "tbSeasonEp";
            this.tbSeasonEp.Size = new System.Drawing.Size(100, 20);
            this.tbSeasonEp.TabIndex = 6;
            // 
            // groupBoxSeasonEp
            // 
            this.groupBoxSeasonEp.Controls.Add(this.label2);
            this.groupBoxSeasonEp.Controls.Add(this.label1);
            this.groupBoxSeasonEp.Controls.Add(this.numUpDownSeasons);
            this.groupBoxSeasonEp.Controls.Add(this.btnSeasonEp);
            this.groupBoxSeasonEp.Controls.Add(this.tbSeasonEp);
            this.groupBoxSeasonEp.Controls.Add(this.cbARFetch);
            this.groupBoxSeasonEp.Location = new System.Drawing.Point(515, 30);
            this.groupBoxSeasonEp.Name = "groupBoxSeasonEp";
            this.groupBoxSeasonEp.Size = new System.Drawing.Size(220, 73);
            this.groupBoxSeasonEp.TabIndex = 7;
            this.groupBoxSeasonEp.TabStop = false;
            this.groupBoxSeasonEp.Text = "Episodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Season";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IMDb Id";
            // 
            // numUpDownSeasons
            // 
            this.numUpDownSeasons.Location = new System.Drawing.Point(145, 19);
            this.numUpDownSeasons.Maximum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.numUpDownSeasons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownSeasons.Name = "numUpDownSeasons";
            this.numUpDownSeasons.Size = new System.Drawing.Size(51, 20);
            this.numUpDownSeasons.TabIndex = 0;
            this.numUpDownSeasons.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUpDownSeasons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbARFetch
            // 
            this.cbARFetch.AutoSize = true;
            this.cbARFetch.Checked = true;
            this.cbARFetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbARFetch.Location = new System.Drawing.Point(12, 44);
            this.cbARFetch.Name = "cbARFetch";
            this.cbARFetch.Size = new System.Drawing.Size(108, 17);
            this.cbARFetch.TabIndex = 9;
            this.cbARFetch.Text = "Auto repeat fetch";
            this.cbARFetch.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AccessibleDescription = "";
            this.dateTimePicker1.AccessibleName = "";
            this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 27);
            this.dateTimePicker1.MaxDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.AccessibleDescription = "";
            this.dateTimePicker2.AccessibleName = "";
            this.dateTimePicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(150, 52);
            this.dateTimePicker2.MaxDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // numUpDays
            // 
            this.numUpDays.AccessibleDescription = "+Days";
            this.numUpDays.Location = new System.Drawing.Point(262, 52);
            this.numUpDays.Name = "numUpDays";
            this.numUpDays.Size = new System.Drawing.Size(43, 20);
            this.numUpDays.TabIndex = 11;
            this.numUpDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUpDays.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // btnScanSeries
            // 
            this.btnScanSeries.Location = new System.Drawing.Point(374, 75);
            this.btnScanSeries.Name = "btnScanSeries";
            this.btnScanSeries.Size = new System.Drawing.Size(103, 22);
            this.btnScanSeries.TabIndex = 12;
            this.btnScanSeries.Text = "Save Series Info";
            this.btnScanSeries.UseVisualStyleBackColor = true;
            this.btnScanSeries.Click += new System.EventHandler(this.btnScanSeries_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(117, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Από:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(116, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Έως:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(259, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "# ημερών (Loop)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(216, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Βήμα 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(409, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Βήμα 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.Location = new System.Drawing.Point(609, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Βήμα 3";
            // 
            // cbStep2
            // 
            this.cbStep2.AutoSize = true;
            this.cbStep2.Checked = true;
            this.cbStep2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStep2.Location = new System.Drawing.Point(391, 33);
            this.cbStep2.Name = "cbStep2";
            this.cbStep2.Size = new System.Drawing.Size(76, 17);
            this.cbStep2.TabIndex = 19;
            this.cbStep2.Text = "Completed";
            this.cbStep2.UseVisualStyleBackColor = true;
            this.cbStep2.Visible = false;
            // 
            // tbApiKey
            // 
            this.tbApiKey.AccessibleDescription = "Api Key";
            this.tbApiKey.Location = new System.Drawing.Point(11, 29);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(88, 20);
            this.tbApiKey.TabIndex = 20;
            this.tbApiKey.UseSystemPasswordChar = true;
            this.tbApiKey.WordWrap = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Api Key";
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(842, 351);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.cbStep2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnScanSeries);
            this.Controls.Add(this.numUpDays);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnAdvanceSearch);
            this.Controls.Add(this.btnPopularTV);
            this.Controls.Add(this.rtbConsole1);
            this.Controls.Add(this.btnSeries1);
            this.Controls.Add(this.groupBoxSeasonEp);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxSeasonEp.ResumeLayout(false);
            this.groupBoxSeasonEp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSeasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}