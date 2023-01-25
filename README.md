<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.8


<a name="dependencies"></a>
## Dependencies
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package Newtonsoft.Json
```

<a name="packaging"></a>
## Packaging
- There is in the folder TVSeriesApp setup wizard 
...

<a name="getting-started"></a>
## Getting Started
Before use this application is compulsoty to receive an API-key from the following link

- https://imdb-api.com/Identity/Account/Register

The Database Schema you can find it in SQLQueries folder. There is also a backup file of MSSQL database in the folder MSSQLDatabase with sample data.
If you need SQL login, the default user name is 'user' without a password.   


<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to */*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*MoviesApiApi* | [**APIAwardsApiKeyIdGet**](docs/MoviesApiApi.md#apiawardsapikeyidget) | **GET** /API/Awards/{apiKey}/{id} | 
*MoviesApiApi* | [**APIBoxOfficeAllTimeApiKeyGet**](docs/MoviesApiApi.md#apiboxofficealltimeapikeyget) | **GET** /API/BoxOfficeAllTime/{apiKey} | 
*MoviesApiApi* | [**APIBoxOfficeApiKeyGet**](docs/MoviesApiApi.md#apiboxofficeapikeyget) | **GET** /API/BoxOffice/{apiKey} | 
*MoviesApiApi* | [**APIComingSoonApiKeyGet**](docs/MoviesApiApi.md#apicomingsoonapikeyget) | **GET** /API/ComingSoon/{apiKey} | 
*MoviesApiApi* | [**APICompanyApiKeyIdGet**](docs/MoviesApiApi.md#apicompanyapikeyidget) | **GET** /API/Company/{apiKey}/{id} | 
*MoviesApiApi* | [**APIExternalSitesApiKeyIdGet**](docs/MoviesApiApi.md#apiexternalsitesapikeyidget) | **GET** /API/ExternalSites/{apiKey}/{id} | 
*MoviesApiApi* | [**APIFAQApiKeyIdGet**](docs/MoviesApiApi.md#apifaqapikeyidget) | **GET** /API/FAQ/{apiKey}/{id} | 
*MoviesApiApi* | [**APIFullCastApiKeyIdGet**](docs/MoviesApiApi.md#apifullcastapikeyidget) | **GET** /API/FullCast/{apiKey}/{id} | 
*MoviesApiApi* | [**APIIMDbListApiKeyIdGet**](docs/MoviesApiApi.md#apiimdblistapikeyidget) | **GET** /API/IMDbList/{apiKey}/{id} | 
*MoviesApiApi* | [**APIImagesApiKeyIdGet**](docs/MoviesApiApi.md#apiimagesapikeyidget) | **GET** /API/Images/{apiKey}/{id} | 
*MoviesApiApi* | [**APIImagesApiKeyIdOptionsGet**](docs/MoviesApiApi.md#apiimagesapikeyidoptionsget) | **GET** /API/Images/{apiKey}/{id}/{options} | 
*MoviesApiApi* | [**APIInTheatersApiKeyGet**](docs/MoviesApiApi.md#apiintheatersapikeyget) | **GET** /API/InTheaters/{apiKey} | 
*MoviesApiApi* | [**APIKeywordApiKeyIdGet**](docs/MoviesApiApi.md#apikeywordapikeyidget) | **GET** /API/Keyword/{apiKey}/{id} | 
*MoviesApiApi* | [**APIMetacriticReviewsApiKeyIdGet**](docs/MoviesApiApi.md#apimetacriticreviewsapikeyidget) | **GET** /API/MetacriticReviews/{apiKey}/{id} | 
*MoviesApiApi* | [**APIMostPopularMoviesApiKeyGet**](docs/MoviesApiApi.md#apimostpopularmoviesapikeyget) | **GET** /API/MostPopularMovies/{apiKey} | 
*MoviesApiApi* | [**APIMostPopularTVsApiKeyGet**](docs/MoviesApiApi.md#apimostpopulartvsapikeyget) | **GET** /API/MostPopularTVs/{apiKey} | 
*MoviesApiApi* | [**APINameApiKeyIdGet**](docs/MoviesApiApi.md#apinameapikeyidget) | **GET** /API/Name/{apiKey}/{id} | 
*MoviesApiApi* | [**APINameAwardsApiKeyIdGet**](docs/MoviesApiApi.md#apinameawardsapikeyidget) | **GET** /API/NameAwards/{apiKey}/{id} | 
*MoviesApiApi* | [**APIPostersApiKeyIdGet**](docs/MoviesApiApi.md#apipostersapikeyidget) | **GET** /API/Posters/{apiKey}/{id} | 
*MoviesApiApi* | [**APIRatingsApiKeyIdGet**](docs/MoviesApiApi.md#apiratingsapikeyidget) | **GET** /API/Ratings/{apiKey}/{id} | 
*MoviesApiApi* | [**APIReviewsApiKeyIdGet**](docs/MoviesApiApi.md#apireviewsapikeyidget) | **GET** /API/Reviews/{apiKey}/{id} | 
*MoviesApiApi* | [**APISearchAllApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchallapikeyexpressionget) | **GET** /API/SearchAll/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchapikeyexpressionget) | **GET** /API/Search/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchCompanyApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchcompanyapikeyexpressionget) | **GET** /API/SearchCompany/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchEpisodeApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchepisodeapikeyexpressionget) | **GET** /API/SearchEpisode/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchKeywordApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchkeywordapikeyexpressionget) | **GET** /API/SearchKeyword/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchMovieApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchmovieapikeyexpressionget) | **GET** /API/SearchMovie/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchNameApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchnameapikeyexpressionget) | **GET** /API/SearchName/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchSeriesApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchseriesapikeyexpressionget) | **GET** /API/SearchSeries/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISearchTitleApiKeyExpressionGet**](docs/MoviesApiApi.md#apisearchtitleapikeyexpressionget) | **GET** /API/SearchTitle/{apiKey}/{expression} | 
*MoviesApiApi* | [**APISeasonEpisodesApiKeyIdSeasonNumberGet**](docs/MoviesApiApi.md#apiseasonepisodesapikeyidseasonnumberget) | **GET** /API/SeasonEpisodes/{apiKey}/{id}/{seasonNumber} | 
*MoviesApiApi* | [**APITop250MoviesApiKeyGet**](docs/MoviesApiApi.md#apitop250moviesapikeyget) | **GET** /API/Top250Movies/{apiKey} | 
*MoviesApiApi* | [**APITop250TVsApiKeyGet**](docs/MoviesApiApi.md#apitop250tvsapikeyget) | **GET** /API/Top250TVs/{apiKey} | 
*MoviesApiApi* | [**APITrailerApiKeyIdGet**](docs/MoviesApiApi.md#apitrailerapikeyidget) | **GET** /API/Trailer/{apiKey}/{id} | 
*MoviesApiApi* | [**APIUsageApiKeyGet**](docs/MoviesApiApi.md#apiusageapikeyget) | **GET** /API/Usage/{apiKey} | 
*MoviesApiApi* | [**APIUserRatingsApiKeyIdGet**](docs/MoviesApiApi.md#apiuserratingsapikeyidget) | **GET** /API/UserRatings/{apiKey}/{id} | 
*MoviesApiApi* | [**APIYouTubeTrailerApiKeyIdGet**](docs/MoviesApiApi.md#apiyoutubetrailerapikeyidget) | **GET** /API/YouTubeTrailer/{apiKey}/{id} | 
*MoviesApiApi* | [**LangAPIReportApiKeyIdGet**](docs/MoviesApiApi.md#langapireportapikeyidget) | **GET** /{lang}/API/Report/{apiKey}/{id} | 
*MoviesApiApi* | [**LangAPIReportApiKeyIdOptionsGet**](docs/MoviesApiApi.md#langapireportapikeyidoptionsget) | **GET** /{lang}/API/Report/{apiKey}/{id}/{options} | 
*MoviesApiApi* | [**LangAPITitleApiKeyIdGet**](docs/MoviesApiApi.md#langapititleapikeyidget) | **GET** /{lang}/API/Title/{apiKey}/{id} | 
*MoviesApiApi* | [**LangAPITitleApiKeyIdOptionsGet**](docs/MoviesApiApi.md#langapititleapikeyidoptionsget) | **GET** /{lang}/API/Title/{apiKey}/{id}/{options} | 
*MoviesApiApi* | [**LangAPIWikipediaApiKeyIdGet**](docs/MoviesApiApi.md#langapiwikipediaapikeyidget) | **GET** /{lang}/API/Wikipedia/{apiKey}/{id} | 

<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.ActorShort](docs/ActorShort.md)
 - [Model.AwardData](docs/AwardData.md)
 - [Model.AwardEvent](docs/AwardEvent.md)
 - [Model.AwardOutcome](docs/AwardOutcome.md)
 - [Model.AwardOutcomeDetail](docs/AwardOutcomeDetail.md)
 - [Model.BoxOfficeAllTimeData](docs/BoxOfficeAllTimeData.md)
 - [Model.BoxOfficeAllTimeDataDetail](docs/BoxOfficeAllTimeDataDetail.md)
 - [Model.BoxOfficeShort](docs/BoxOfficeShort.md)
 - [Model.BoxOfficeWeekendData](docs/BoxOfficeWeekendData.md)
 - [Model.BoxOfficeWeekendDataDetail](docs/BoxOfficeWeekendDataDetail.md)
 - [Model.CastMovie](docs/CastMovie.md)
 - [Model.CastShort](docs/CastShort.md)
 - [Model.CastShortItem](docs/CastShortItem.md)
 - [Model.CompanyData](docs/CompanyData.md)
 - [Model.CompanyShort](docs/CompanyShort.md)
 - [Model.EpisodeShortDetail](docs/EpisodeShortDetail.md)
 - [Model.ExternalSiteData](docs/ExternalSiteData.md)
 - [Model.ExternalSiteItem](docs/ExternalSiteItem.md)
 - [Model.FAQData](docs/FAQData.md)
 - [Model.FAQDetail](docs/FAQDetail.md)
 - [Model.FullCastData](docs/FullCastData.md)
 - [Model.IMDbListData](docs/IMDbListData.md)
 - [Model.IMDbListDataDetail](docs/IMDbListDataDetail.md)
 - [Model.ImageData](docs/ImageData.md)
 - [Model.ImageDataDetail](docs/ImageDataDetail.md)
 - [Model.KeyValueItem](docs/KeyValueItem.md)
 - [Model.KeywordData](docs/KeywordData.md)
 - [Model.KnownFor](docs/KnownFor.md)
 - [Model.LanguageUrl](docs/LanguageUrl.md)
 - [Model.MetacriticReviewData](docs/MetacriticReviewData.md)
 - [Model.MetacriticReviewDetail](docs/MetacriticReviewDetail.md)
 - [Model.MostPopularData](docs/MostPopularData.md)
 - [Model.MostPopularDataDetail](docs/MostPopularDataDetail.md)
 - [Model.MovieShort](docs/MovieShort.md)
 - [Model.NameAwardData](docs/NameAwardData.md)
 - [Model.NameAwardEvent](docs/NameAwardEvent.md)
 - [Model.NameAwardOutcome](docs/NameAwardOutcome.md)
 - [Model.NameAwardOutcomeDetail](docs/NameAwardOutcomeDetail.md)
 - [Model.NameData](docs/NameData.md)
 - [Model.NewMovieData](docs/NewMovieData.md)
 - [Model.NewMovieDataDetail](docs/NewMovieDataDetail.md)
 - [Model.PosterData](docs/PosterData.md)
 - [Model.PosterDataItem](docs/PosterDataItem.md)
 - [Model.RatingData](docs/RatingData.md)
 - [Model.ReviewData](docs/ReviewData.md)
 - [Model.ReviewDetail](docs/ReviewDetail.md)
 - [Model.SearchData](docs/SearchData.md)
 - [Model.SearchResult](docs/SearchResult.md)
 - [Model.SeasonEpisodeData](docs/SeasonEpisodeData.md)
 - [Model.SimilarShort](docs/SimilarShort.md)
 - [Model.StarShort](docs/StarShort.md)
 - [Model.TitleData](docs/TitleData.md)
 - [Model.Top250Data](docs/Top250Data.md)
 - [Model.Top250DataDetail](docs/Top250DataDetail.md)
 - [Model.TrailerData](docs/TrailerData.md)
 - [Model.TvEpisodeInfo](docs/TvEpisodeInfo.md)
 - [Model.TvSeriesInfo](docs/TvSeriesInfo.md)
 - [Model.UsageData](docs/UsageData.md)
 - [Model.UserRatingData](docs/UserRatingData.md)
 - [Model.UserRatingDataDemographic](docs/UserRatingDataDemographic.md)
 - [Model.UserRatingDataDemographicDetail](docs/UserRatingDataDemographicDetail.md)
 - [Model.UserRatingDataDetail](docs/UserRatingDataDetail.md)
 - [Model.WikipediaData](docs/WikipediaData.md)
 - [Model.WikipediaDataPlot](docs/WikipediaDataPlot.md)
 - [Model.YouTubeData](docs/YouTubeData.md)
 - [Model.YouTubeDataItem](docs/YouTubeDataItem.md)
 - [Model.YouTubePlaylistData](docs/YouTubePlaylistData.md)
 - [Model.YouTubePlaylistDataItem](docs/YouTubePlaylistDataItem.md)
 - [Model.YouTubeTrailerData](docs/YouTubeTrailerData.md)

<a name="documentation-for-authorization"></a>
## Documentation for Authorization

All endpoints do not require authorization.
