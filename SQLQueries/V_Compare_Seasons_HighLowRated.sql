/****** Script for SelectTopNRows command from SSMS  ******/
SELECT count(serinf.[Id])
	   ,CASE
	   		WHEN [Seasons] between 1 AND 200 THEN [Seasons]
			WHEN [Seasons] > 200 THEN 1
			WHEN [Seasons] is null THEN 1
			WHEN [Seasons] = 0 THEN 1
			ELSE [Seasons]
			END as 'Seasons'
		,CASE
			WHEN [IMDbRating] < 8 THEN 'LOW'
			WHEN [IMDbRating] >= 8 THEN 'HIGH'
			END as 'Rating'
FROM [IMDbSeriesInfo] serinf, [IMDbSeries] ser
WHERE  serinf.[Id]= ser.[Id] AND
		IMDbRatingVotes >= 500   -- Πιο έγκυρη βαθμολογία
GROUP by
	CASE
		WHEN [Seasons] between 1 AND 200 THEN [Seasons]
		WHEN [Seasons] > 200 THEN 1
		WHEN [Seasons] is null THEN 1
		WHEN [Seasons] = 0 THEN 1
		ELSE [Seasons]
		END
	,CASE
		WHEN [IMDbRating] < 8 THEN 'LOW'
		WHEN [IMDbRating] >= 8 THEN 'HIGH'
		END
order by [Seasons] DESC, count(serinf.[Id]) DESC