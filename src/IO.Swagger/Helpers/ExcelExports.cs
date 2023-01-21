using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using EdeilControl.Models;
using System.IO;

namespace EdeilControl.Helpers
{

    public class XLexportStypes
    {
        public UInt32Value NumberStyle;
        public UInt32Value DateStyle;
        public UInt32Value StringStyle;
        public UInt32Value AmountStyle;

        public UInt32Value ocNumberStringStyle;
        public UInt32Value ocDateStyle;
        public UInt32Value ocDecimalStyle;
        public UInt32Value ocNumberStyle;

        public UInt32Value prjDateStyle;
        public UInt32Value prjNumberStyle;

        public UInt32Value aposNnumberStyle;
        public UInt32Value aposIntStyle;
        public UInt32Value aposDateStyle;
        public UInt32Value aposStringStyle;

        //Symvaseis
        public UInt32Value symbIntStyle = 26;
        public UInt32Value symbStringStyle = 10;
        public UInt32Value symbNumberStringStyle = 4;
        public UInt32Value symbDateStyle = 5;
        public UInt32Value symbDecimalStyle = 25;
        public UInt32Value symbNumberStyle = 6;



        public XLexportStypes()
        {
            setNormalStyles();
        }

        public void setNormalStyles()
        {
            // Set Normal Colors
            NumberStyle = 4;
            DateStyle = 5;
            StringStyle = 7;
            AmountStyle = 8;
            // OwnContribution
            ocNumberStringStyle = 4;
            ocDateStyle = 5;
            ocDecimalStyle = 7;
            ocNumberStyle = 8;
            //PrjSummary
            prjDateStyle = 15;
            prjNumberStyle = 2;
            //Aposveseis
            aposNnumberStyle = 1;
            aposIntStyle = 7;
            aposDateStyle = 3;
            aposStringStyle = 6;
            //Symvaseis
            symbIntStyle = 12;
            symbStringStyle = 10;
            symbNumberStringStyle = 4;
            symbDateStyle = 5;
            symbDecimalStyle = 11;
            symbNumberStyle = 6;


    }

    public void setCancelledStyles()
        {
            NumberStyle = 23;
            DateStyle = 24;
            StringStyle = 27;
            AmountStyle = 26;
            // OwnContribution
            ocNumberStringStyle = 23;
            ocDateStyle = 24;
            ocDecimalStyle = 26;
            ocNumberStyle = 27;
        }
    }

    public class ExcelExports
    {

        public byte[] getGenericInvoiceListToExcel(IQueryable<invHeader> myData)
        {
            string wsName = "ΤΠΥ";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";
            byte[] res;

            mfile = Globals.XL_FISCALDOCUMENTSLIST_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);

            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 6;
                int rownumA; int rownumB; int rownumC; int rownumD;
                rownumA = rownum;
                rownumB = rownum;
                rownumC = rownum;
                rownumD = rownum;

                foreach (var item in myData)
                {
                    // rownum += 1;
                    if (item.invTaxDocument.tdID == 1)
                    {
                        wsName = "ΤΠΥ";
                        rownumA +=1 ;
                        rownum = rownumA;

                    }
                    else if (item.invTaxDocument.tdID == 2)
                    {
                        wsName = "ΠΤΠΥ";
                        rownumB += 1;
                        rownum = rownumB;
                    }
                    else if (item.invTaxDocument.tdID == 3)
                    {
                        wsName = "ΤΕΕ";
                        rownumC += 1;
                        rownum = rownumC;
                    }
                    else
                    {
                        wsName = "ΠΤΕΕ";
                        rownumD += 1;
                        rownum = rownumD;
                    }
                    XLexportStypes p = new XLexportStypes();
                    if(item.invhIsCanceled == 1) { p.setCancelledStyles(); }

                    UpdateValue(wsName, "A", rownum, item.invhNumber.ToString(), p.NumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.invhIssueDate.ToOADate().ToString(), p.DateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.invhCustName.ToString(), p.DateStyle, CellValues.InlineString, lwbPart, false);
                    if (item.invhCustVatNo != null)
                    {
                        UpdateValue(wsName, "D", rownum, item.invhCustVatNo.ToString(), p.StringStyle, CellValues.InlineString, lwbPart, false);
                    }
                    UpdateValue(wsName, "E", rownum, item.invDetails.Sum<invDetail>(s => s.idtLineUnitPriceNoVAT - s.idtLineUnitPriceNoVAT * s.invHeader.invReductionType.RTPercentange / 100).ToString().Replace(",", "."), p.AmountStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.invDetails.Sum<invDetail>(s => s.idtLineVATAmount).ToString().Replace(",", "."), p.AmountStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.invDetails.Sum<invDetail>(s => s.idtLineVATAmount + s.idtLineUnitPriceNoVAT - s.idtLineUnitPriceNoVAT * s.invHeader.invReductionType.RTPercentange / 100).ToString().Replace(",", "."), p.AmountStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "H", rownum, item.invDetails.FirstOrDefault<invDetail>().idtProjectEPY, p.NumberStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "I", rownum, item.invDetails.FirstOrDefault<invDetail>().idtProjectID, p.StringStyle, CellValues.InlineString, lwbPart, false);
                    if (item.invAdditionalReferences.Count() > 0)
                    {
                        UpdateValue(wsName, "J", rownum, String.Join(",", item.invAdditionalReferences.Select(s => s.invDocNo).ToList()), p.NumberStyle, CellValues.InlineString, lwbPart, false);
                    } else
                    {
                        UpdateValue(wsName, "J", rownum, "", p.NumberStyle, CellValues.InlineString, lwbPart, false);
                    }
                }

                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;

        }

        public byte[] getAposveseisToExcel(dsSQL ds)
        {
            string wsName = "Αποσβέσεις";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";

            byte[] res;

            mfile = Globals.XL_APOSVESEIS_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);

            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 9;

                foreach (var item in ds.Aposveseis)
                {
                    if (rownum == 9)
                    {
                        // Do it only once
                        UpdateValue(wsName, "B", 6, item.mYear.ToString(), 0, CellValues.Number, lwbPart, false);
                    }

                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "A", rownum, item.mCode.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.C_ER.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.EPY.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);                   
                    UpdateValue(wsName, "D", rownum, item.D_REPI.ToOADate().ToString(), p.aposDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.P_GR_PAR.Replace("\x00", "").ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.POSO_GR_PAR.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.POSO_FPA.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "H", rownum, item.mAposv.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "I", rownum, item.mAnaposv.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "J", rownum, item.mMonths.ToString().Replace(",", "."), p.aposIntStyle, CellValues.Number, lwbPart, false);
                    rownum += 1;
                }


               


                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;

        }

        public byte[] getAssetListToExcel(dsSQL ds)
        {
            string wsName = "Πάγια";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";

            byte[] res;

            mfile = Globals.XL_ASSETLIST_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);

            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 9;
                UpdateValue(wsName, "B", 6, DateTime.Now.Year.ToString(), 0, CellValues.Number, lwbPart, false);
                foreach (var item in ds.Assets)
                {

                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "A", rownum, item.mCode.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.C_ER.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.EPY.ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "D", rownum, item.D_REPI.ToOADate().ToString(), p.aposDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.AFM_DIK.Replace("\x00", "").ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.DIK.Replace("\x00", "").ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.P_GR_PAR.Replace("\x00", "").ToString(), p.aposStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "H", rownum, item.POSO_GR_PAR.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "I", rownum, item.POSO_FPA.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "J", rownum, item.TREX_AKSIA.ToString().Replace(",", "."), p.aposNnumberStyle, CellValues.Number, lwbPart, false);
                    rownum += 1;
                }





                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;

        }
        public byte[] getProjectSummaryToExcel(dsOracleDB ds)
        {
            string wsName = "Κινήσεις";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";
            string cER = "";
            string pER = "";

            byte[] res;

            mfile = Globals.XL_PROJECTSUMMARY_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);

            cER = ds.V_ONX.FirstOrDefault().C_ER;
            pER = ds.V_ONX.FirstOrDefault().T_ER_G;


            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 9;
                
                // KINISEIS
                UpdateValue(wsName, "A", 6, cER, 0, CellValues.InlineString, lwbPart, false);
                UpdateValue(wsName, "B", 6, pER, 0, CellValues.InlineString, lwbPart, false);

                foreach (var item in ds.V_PRJ_DETAILS2)
                {
                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "A", rownum, item.D_KIN.ToOADate().ToString(), 8, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.IsP_KINNull() ? "" : item.P_KIN.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.IsN_PARNull() ? "" : item.N_PAR.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "D", rownum, item.IsDIKNull() ? "" : item.DIK.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.POSO.ToString().Replace(",", "."), 0, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.IsAITNull() ? "" : item.AIT.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.P_KAT_DAP.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    rownum += 1;
                }


                // KONDYLIA
                wsName = "Συνολική Εικόνα";
                UpdateValue(wsName, "A", 6, cER, 0, CellValues.InlineString, lwbPart, false);
                UpdateValue(wsName, "B", 6, pER, 0, CellValues.InlineString, lwbPart, false);

                foreach (var item in ds.V_ONX)
                {
                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "B", 7, item.EPY.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", 7, item.TMH.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", 8, item.IsC_TOMNull() ? "" : item.TOM.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "B", 9, item.EPO_XRH.ToString() + " " + item.P_PAK.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", 9, item.D_START_ER.Date.ToOADate().ToString(), 11, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", 10, item.P_NOM.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", 10, item.D_END_ER.Date.ToOADate().ToString(), 11, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", 11, item.IsN_CONDRNull() ? "" : item.N_CONDR.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "F", 11, item.D_EGR_ER.Date.ToOADate().ToString(), 11, CellValues.Number, lwbPart, false);
                    break;
                }


                rownum = 18;

                foreach (var item in ds.V_PRJ_SUM_ANA_KONDYLI)
                {
                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "A", rownum, item.C_KAT_DAP.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.P_KAT_DAP.ToString(), 0, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.PROYPOL.ToString().Replace(",", "."), p.prjNumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "D", rownum, item.EKSODA.ToString().Replace(",", "."), p.prjNumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.PROPLHROMES.ToString().Replace(",", "."), p.prjNumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.YPOL_DAP.ToString().Replace(",", "."), p.prjNumberStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.DESMEYMENO.ToString().Replace(",", "."), p.prjNumberStyle, CellValues.Number, lwbPart, false);

                    rownum += 1;
                }

                // DIATHESIMA
                foreach (var item in ds.V_PRJ_DIATHESIMA)
                {
                    UpdateValue(wsName, "B", 13, item.DIATHES.ToString().Replace(",", "."), 2, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", 13, item.PROYP.ToString().Replace(",", "."), 2, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", 14, item.DESM.ToString().Replace(",", "."), 2, CellValues.Number, lwbPart, false);
                    rownum += 1;
                }


                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;

        }

        public byte[] getAggrListToExcel(dsOracleDB ds)
        {
            string wsName = "Συμβάσεις";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";
            string cER = "";
            string pER = "";

            byte[] res;

            mfile = Globals.XL_AGGRLIST_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);


            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 7;

                foreach (var item in ds.V_SYMB_SEARCH)
                {
                    XLexportStypes p = new XLexportStypes();
                    // if (item.invhIsCanceled == 1) { p.setCancelledStyles(); }
                    p.setNormalStyles();
                    UpdateValue(wsName, "A", rownum, (rownum - 7 + 1).ToString(), p.symbIntStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.C_ER.ToString(), p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.D_START_SYMB.ToOADate().ToString(), p.symbDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "D", rownum, item.D_END_SYMB.ToOADate().ToString(), p.symbDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.POSO_SYMB.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.YPOL_SYMB.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, item.POSO_FPA_SYMB.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "H", rownum, item.IsERG_EISFNull() ? (0).ToString() : item.ERG_EISF.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "I", rownum, item.IsYPOL_ERG_EISFNull() ? (0).ToString() : item.YPOL_ERG_EISF.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "J", rownum, item.IsYPOL_KATHNull()? (0).ToString() : item.YPOL_KATH.ToString().Replace(",", "."), p.symbDecimalStyle, CellValues.Number, lwbPart, false);

                    UpdateValue(wsName, "K", rownum, item.IsAFM_DIKNull() ? "-" : item.AFM_DIK, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "L", rownum, item.EPWN_DIK, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "M", rownum, item.IsON_DIKNull() ? "-" : item.ON_DIK, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "N", rownum, item.IsP_SYMBNull() ? "-" : item.P_SYMB.Replace("\0",""), p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "O", rownum, item.P_KAT_DAP, p.symbStringStyle, CellValues.InlineString, lwbPart, false);

                    UpdateValue(wsName, "P", rownum, item.IsADANull() ? "-" : item.ADA, p.symbStringStyle, CellValues.InlineString, lwbPart, false);

                    UpdateValue(wsName, "Q", rownum, item.IsCEIDSYMBNull() ? "-" : item.CEIDSYMB, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "R", rownum, item.IsP_EIDOSNull() ? "-" : item.P_EIDOS, p.symbStringStyle, CellValues.InlineString, lwbPart, false);                    
                    UpdateValue(wsName, "S", rownum, item.IsP_ASF_PACKNull() ? "-" : item.P_ASF_PACK, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "T", rownum, item.IsP_COD_EIDIKNull() ? "-" : item.P_COD_EIDIK, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "U", rownum, item.IsP_COD_PACK_KALNull() ? "-" : item.P_COD_PACK_KAL, p.symbStringStyle, CellValues.InlineString, lwbPart, false);
                    UpdateValue(wsName, "V", rownum, item.IsD_AKNull() ? "" : item.D_AK.ToOADate().ToString(), p.symbDateStyle, CellValues.Number, lwbPart, false);
                    rownum += 1;
                }



                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;

        }
        public byte[] getGenericOwnContrToExcel(List<agrOwnContribution> myData)
        {
            string wsName = "Ιδία Συμμετοχή";  // Name of the Sheet to modify
            string mfile = "";
            string strDoc = "";
            byte[] res;

            mfile = Globals.XL_OWNCONTRIBUTIONLIST_TEMPLATE;
            strDoc = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Templates"), mfile);
            byte[] byteArray = System.IO.File.ReadAllBytes(strDoc);

            WorkbookPart lwbPart;
            SpreadsheetDocument lxlDoc;

            // Do the stream manipulation
            using (MemoryStream mem = new MemoryStream())
            {
                //Write the file to  stream
                mem.Write(byteArray, 0, (int)byteArray.Length);

                // Open a SpreadsheetDocument based on a stream.
                lxlDoc = SpreadsheetDocument.Open(mem, true); //Open
                lwbPart = lxlDoc.WorkbookPart;

                int rownum = 6;

                XLexportStypes p = new XLexportStypes();

                foreach (var item in myData)
                {
                    rownum += 1;
                    if (item.ocCancelled == 1)
                    {
                        p.setCancelledStyles();
                    } else
                    {
                        p.setNormalStyles();
                    }
                    UpdateValue(wsName, "A", rownum, item.ocFiscalNo.ToString(), p.ocNumberStringStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "B", rownum, item.ocAgreementDate.ToOADate().ToString(), p.ocDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "C", rownum, item.ocAggrApprovedTS.Value.ToOADate().ToString(), p.ocDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "D", rownum, item.ocProjectCode.ToString(), p.ocNumberStringStyle, CellValues.SharedString, lwbPart, false);
                    // UpdateValue(wsName, "E", rownum, item.ocProjectTitle.ToString(), 4, CellValues.SharedString, lwbPart, false);
                    UpdateValue(wsName, "E", rownum, item.ocRate.Value.ToString().Replace(",", "."), p.ocDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "F", rownum, item.ocHours.Value.ToString().Replace(",", "."), p.ocDecimalStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "G", rownum, "E"+rownum.ToString()+"*F"+rownum.ToString(), p.ocDecimalStyle, CellValues.Number, lwbPart, true);
                    UpdateValue(wsName, "H", rownum, item.ocResearcherLastName.ToString(), p.ocNumberStringStyle, CellValues.SharedString, lwbPart, false);
                    UpdateValue(wsName, "I", rownum, item.ocResearcherFirstName.ToString(), p.ocNumberStringStyle, CellValues.SharedString, lwbPart, false);
                    UpdateValue(wsName, "J", rownum, item.ocSciRespLastName.ToString(), p.ocNumberStringStyle, CellValues.SharedString, lwbPart, false);
                    UpdateValue(wsName, "K", rownum, item.ocSciRespFirstName.ToString(), p.ocNumberStringStyle, CellValues.SharedString, lwbPart, false);
                    UpdateValue(wsName, "L", rownum, item.ocAggrFromDate.Value.ToOADate().ToString(), p.ocDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "M", rownum, item.ocAggrToDate.Value.ToOADate().ToString(), p.ocDateStyle, CellValues.Number, lwbPart, false);
                    UpdateValue(wsName, "N", rownum, item.ocClasserNo.ToString(), p.ocNumberStyle, CellValues.Number, lwbPart, false);
                }

                lwbPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                lwbPart.Workbook.CalculationProperties.CalculationMode = CalculateModeValues.Auto;
                lwbPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                lxlDoc.Close();

                // Save the modified stream to a new array
                res = mem.ToArray();
            }

            return res;
        }


        // Given a Worksheet and an address (like "AZ254"), either return a 
        // cell reference, or create the cell reference and return it.
        private Cell InsertCellInWorksheet(Worksheet ws, string addressName)
        {
            SheetData sheetData = ws.GetFirstChild<SheetData>();
            Cell cell = null;

            UInt32 rowNumber = GetRowIndex(addressName);
            Row row = GetRow(sheetData, rowNumber);

            // If the cell you need already exists, return it.
            // If there is not a cell with the specified column name, insert one.  
            Cell refCell = row.Elements<Cell>().
                Where(c => c.CellReference.Value == addressName).FirstOrDefault();
            if (refCell != null)
            {
                cell = refCell;
            }
            else
            {
                cell = CreateCell(row, addressName);
            }
            return cell;
        }

        // Add a cell with the specified address to a row.
        private Cell CreateCell(Row row, String address)
        {
            Cell cellResult;
            Cell refCell = null;

            // Cells must be in sequential order according to CellReference. 
            // Determine where to insert the new cell.
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, address, true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }

            cellResult = new Cell();
            cellResult.CellReference = address;

            row.InsertBefore(cellResult, refCell);
            return cellResult;
        }

        // Return the row at the specified rowIndex located within
        // the sheet data passed in via wsData. If the row does not
        // exist, create it.
        private Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }

        // Given an Excel address such as E5 or AB128, GetRowIndex
        // parses the address and returns the row index.
        private UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }


        private bool UpdateValue(string sheetName, string colName, Int32 rowNum, string value,
                                UInt32Value styleIndex, CellValues valType, WorkbookPart wbPart, bool IsFormula)
        {
            // Assume failure.
            bool updated = false;
            string addressName = colName + rowNum.ToString();


            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where(
                (s) => s.Name == sheetName).FirstOrDefault();

            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);
                cell.RemoveAllChildren();  // Remove whatever is in there
                cell.DataType = new EnumValue<CellValues>(valType);
                if (IsFormula)
                { 
                    // If there is a formula to be added add it without value so it will be recalculated
                    // On Open
                    CellFormula cf = new CellFormula(value);
                    cell.CellFormula = cf;
                }
                else
                {
                    if (valType == CellValues.SharedString || valType == CellValues.String)
                    {
                        int stringIndex = InsertSharedStringItem(wbPart, value);
                        cell.CellValue = new CellValue(stringIndex.ToString());
                        addIgnoreError(value, addressName, ws);
                    }
                    else if (valType == CellValues.InlineString)
                    {
                        cell.InlineString = new InlineString(new Text(value));
                        addIgnoreError(value, addressName, ws);
                    }
                    else
                    {
                        cell.CellValue = new CellValue(value);
                    }
                }

                

                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;
                // Save the worksheet.
                ws.Save();
                updated = true;
            }

            return updated;
        }


        private bool addIgnoreError(string val, string celladdress, Worksheet ws)
        {
            bool res = false;
            double aNum = 0;
            if ( Double.TryParse(val, out aNum))
            {
                // Worksheet ws = wbPart.WorksheetParts.FirstOrDefault().Worksheet;
                IgnoredErrors iers = new IgnoredErrors();
                try
                {
                    if (ws.ChildElements[9] != null)
                        {
                            iers = (IgnoredErrors)ws.ChildElements[9];
                            foreach (IgnoredError igE in iers)
                            {
                                igE.SequenceOfReferences.Items.Add(celladdress);
                            }

                        }
                }
                catch (Exception ex)
                {
                    Utilities.mLog(ex.Message);
                }
                

            }
            return res;
        }

        // Given the main workbook part, and a text value, insert the text into 
        // the shared string table. Create the table if necessary. If the value 
        // already exists, return its index. If it doesn't exist, insert it and 
        // return its new index.
        private int InsertSharedStringItem(WorkbookPart wbPart, string value)
        {
            int index = 0;
            bool found = false;
            var stringTablePart = wbPart
                .GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

            // If the shared string table is missing, something's wrong.
            // Just return the index that you found in the cell.
            // Otherwise, look up the correct text in the table.
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
            }

            var stringTable = stringTablePart.SharedStringTable;
            if (stringTable == null)
            {
                stringTable = new SharedStringTable();
            }

            // Iterate through all the items in the SharedStringTable. 
            // If the text already exists, return its index.
            foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    found = true;
                    break;
                }
                index += 1;
            }

            if (!found)
            {
                stringTable.AppendChild(new SharedStringItem(new Text(value)));
                stringTable.Save();
            }

            return index;
        }

        // This method is used to force a recalculation of cells containing formulas. The
        // CellValue has a cached value of the evaluated formula. This
        // prevents Excel from recalculating the cell even if 
        // calculation is set to automatic.
        private bool RemoveCellValue(string sheetName, string addressName, WorkbookPart wbPart)
        {
            bool returnValue = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().
                Where(s => s.Name == sheetName).FirstOrDefault();
            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                // If there is a cell value, remove it to force a recalculation
                // on this cell.
                if (cell.CellValue != null)
                {
                    cell.CellValue.Remove();
                }

                // Save the worksheet.
                ws.Save();
                returnValue = true;
            }

            return returnValue;
        }
    }
}