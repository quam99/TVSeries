USE IMDB;


--Ερώτημα 1
SELECT count(serinf.[Id]) '#Series'
	   ,CASE
		WHEN [Seasons] > 200 THEN Seasons - Convert(smallint,IsNull(Year(ReleaseDate),Seasons))
		WHEN [Seasons] = 0 THEN 1
		WHEN [Seasons] between 0 AND 200 THEN [Seasons]
		WHEN [Seasons] is null THEN 1
		END as 'Seasons'
		,CASE
		WHEN [IMDbRating] < 1 THEN 'LOW'
		WHEN [IMDbRating] between 1 AND 1.99 THEN '1-2'
		WHEN [IMDbRating] between 2 AND 2.99 THEN '2-3'
		WHEN [IMDbRating] between 3 AND 3.99 THEN '3-4'
		WHEN [IMDbRating] between 4 AND 4.99 THEN '4-5'	
		WHEN [IMDbRating] between 5 AND 5.99 THEN '5-6'
		WHEN [IMDbRating] between 6 AND 6.99 THEN '6-7'
		WHEN [IMDbRating] between 7 AND 7.99 THEN '7-8'
		WHEN [IMDbRating] between 8 AND 8.99 THEN '8-9'
		WHEN [IMDbRating] >= 9 THEN 'TOP'
		END as 'Rating'
		,count(serinf.[Id])/sum(count(serinf.[Id]))

FROM [IMDbSeriesInfo] serinf, [IMDbSeries] ser
WHERE  serinf.[Id]= ser.[Id]
	AND ser.IMDbRatingVotes > 1000
	AND ReleaseDate < '1/1/2019'
GROUP by
	CASE
	WHEN [Seasons] > 200 THEN Seasons - Convert(smallint,IsNull(Year(ReleaseDate),Seasons))
	WHEN [Seasons] = 0 THEN 1
	WHEN [Seasons] between 0 AND 200 THEN [Seasons]
	WHEN [Seasons] is null THEN 1
	END
	,CASE
		WHEN [IMDbRating] < 1 THEN 'LOW'
		WHEN [IMDbRating] between 1 AND 1.99 THEN '1-2'
		WHEN [IMDbRating] between 2 AND 2.99 THEN '2-3'
		WHEN [IMDbRating] between 3 AND 3.99 THEN '3-4'
		WHEN [IMDbRating] between 4 AND 4.99 THEN '4-5'	
		WHEN [IMDbRating] between 5 AND 5.99 THEN '5-6'
		WHEN [IMDbRating] between 6 AND 6.99 THEN '6-7'
		WHEN [IMDbRating] between 7 AND 7.99 THEN '7-8'
		WHEN [IMDbRating] between 8 AND 8.99 THEN '8-9'
		WHEN [IMDbRating] >= 9 THEN 'TOP'
		END
order by Rating DESC, [Seasons] DESC, count(serinf.[Id]) DESC;

-- ερώτημα 2  Ποιός Κύκλος των πιο δημοφιλών σειρών έχει την υψηλότερη/χαμηλότερη βαθμολογία
SELECT s.id, MAX(s.Title) Title, AVG(e.IMDbRating) Rate, e.SeasonNumber, SUM(isnull(e.IMDBRatingCount,0)) Votes, s.IMDbRating
FROM IMDbSeries as s LEFT JOIN IMDbEpisodes as e ON s.Id = e.IMDbId, IMDbSeriesInfo i, 
	(SELECT id FROM IMDbSeries WHERE /*IMDbRating > = 9 AND*/ IMDbRatingVotes > 1500) ss
WHERE	s.Id = i.Id AND
		YEAR(i.ReleaseDate) < 2019 AND
		s.IMDbRating >= 9 AND
		s.IMDbRatingVotes > 1000 AND
		ss.id = s.id AND
		(e.SeasonNumber in (SELECT TOP 1 SeasonNumber FROM IMDbEpisodes WHERE IMDbID = s.id GROUP BY IMDbId, SeasonNumber ORDER BY AVG(IMDBRating)) OR
		e.SeasonNumber in (SELECT TOP 1 SeasonNumber FROM IMDbEpisodes WHERE IMDbID = s.id GROUP BY IMDbId, SeasonNumber ORDER BY AVG(IMDBRating) DESC))
GROUP BY s.id, e.SeasonNumber, s.IMDbRating
--HAVING AVG(e.IMDbRating) > 0
ORDER BY s.IMDbRating DESC, s.id, Rate DESC ;


-- 3 ερώτημα για τα περισσότερα επεισόδια των πιο δημοφιλών σειρών
SELECT imdbid, MAX(s.title), Count(e.EpId) #Episodes, 
	MAX(CASE
		WHEN e.SeasonNumber > 200 THEN SeasonNumber - Convert(smallint,IsNull(Year(ReleaseDate),SeasonNumber))
		WHEN e.SeasonNumber  = 0 THEN 1
		WHEN e.SeasonNumber  between 0 AND 200 THEN SeasonNumber
		WHEN e.SeasonNumber  is null THEN 1
		END) as 'Seasons', 
	AVG(e.imdbrating) Rating, SUM(isnull(e.IMDBRatingCount,0)) Votes
FROM IMDbEpisodes e, IMDbSeriesInfo i, IMDbSeries s
WHERE IMDbId = i.id AND
		IMDBId = s.id
GROUP BY e.IMDbId
ORDER BY Count(e.EpId) DESC, MAX(e.SeasonNumber) DESC;


SELECT e.IMDbId, max(s.Title), e.SeasonNumber, max(EpisodeNumber) #Episodes, avg(e.imdbrating) EpRating, sum(isnull(imdbRatingCount,0)) Votes 
from IMDbSeries s left join imdbEpisodes e on s.Id = e.IMDbId
WHERE e.IMDbId in ('tt5232792',
'tt10116578',
'tt10116578',
'tt11207734',
'tt11207734',
'tt8560994',
'tt8560994',
'tt7678620',
'tt7678620',
'tt7865962',
'tt7865962',
'tt7866314',
'tt7866314',
'tt8284230',
'tt8284230',
'tt12423408',
'tt12423408',
'tt3787912',
'tt3787912',
'tt4834232',
'tt4834232',
'tt6407712',
'tt6407712',
'tt2861424',
'tt2861424',
'tt9169598',
'tt9169598',
'tt0944947',
'tt0944947',
'tt1910272',
'tt1910272',
'tt2147999',
'tt2147999',
'tt2185037',
'tt2185037',
'tt2560140',
'tt2560140',
'tt3212600',
'tt4062640',
'tt4266402',
'tt4266402',
'tt4934214',
'tt4934214',
'tt7248250',
'tt7248250',
'tt9434996',
'tt9434996')
GROUP BY e.IMDbId, SeasonNumber
ORDER BY e.IMDbId, avg(e.imdbrating) DESC, SeasonNumber DESC


-- Στοιχεία για τα επισόδια και τους κύκλους των πιο δημοφιλών σειρών
SELECT e.IMDbId, e.EpId, e.SeasonNumber, e.EpId, e.imdbrating EpRating, isnull(imdbRatingCount,0) Votes 
from imdbEpisodes e 
WHERE e.IMDbId in ('tt5232792',
'tt10116578',
'tt10116578',
'tt11207734',
'tt11207734',
'tt8560994',
'tt8560994',
'tt7678620',
'tt7678620',
'tt7865962',
'tt7865962',
'tt7866314',
'tt7866314',
'tt8284230',
'tt8284230',
'tt12423408',
'tt12423408',
'tt3787912',
'tt3787912',
'tt4834232',
'tt4834232',
'tt6407712',
'tt6407712',
'tt2861424',
'tt2861424',
'tt9169598',
'tt9169598',
'tt0944947',
'tt0944947',
'tt1910272',
'tt1910272',
'tt2147999',
'tt2147999',
'tt2185037',
'tt2185037',
'tt2560140',
'tt2560140',
'tt3212600',
'tt4062640',
'tt4266402',
'tt4266402',
'tt4934214',
'tt4934214',
'tt7248250',
'tt7248250',
'tt9434996',
'tt9434996')
--GROUP BY e.IMDbId, SeasonNumber
ORDER BY e.IMDbId, SeasonNumber, e.EpisodeNumber;



SELECT count(serinf.[Id]) as 'Series #', 
		MAX(CASE
			WHEN Seasons = 0 Then 1
			WHEN Seasons is null Then 1
			WHEN Seasons > 200 then 
				CASE WHEN Seasons - Convert(smallint,IsNull(Year(ReleaseDate),Seasons)) <= 0 THEN 1 ELSE Seasons - Convert(smallint,IsNull(Year(ReleaseDate),Seasons)) END
			ELSE Seasons
		END) as 'Seasons',
		AVG(ser.IMDbRating) as 'Aver. Rating',
		SUM(ISNULL(ser.IMDbRatingVotes,0)) as 'Sum Votes',
		AVG(ser.IMDbRatingVotes) as 'Aver. # Votes',
		(SUM(ISNULL(ser.IMDbRatingVotes,0)/(CASE
			WHEN Seasons = 0 Then 1
			WHEN Seasons > 1990 then 
				CASE WHEN Seasons - Year(serinf.ReleaseDate) <= 0 THEN 1 ELSE Seasons - Year(serinf.ReleaseDate) END
			ELSE Seasons
		END))/count(serinf.[Id])) as 'Aver Votes'
FROM [IMDbSeriesInfo] serinf, [IMDbSeries] ser--, (Select (Seasons - Year(serinf.ReleaseDate))
WHERE  serinf.[Id]= ser.[Id] AND
		serinf.ReleaseDate between '1/1/2010' AND '31/12/2019'
GROUP BY CASE
			WHEN Seasons = 0 Then 1
			WHEN Seasons > 1990 then 
				CASE WHEN Seasons - Year(serinf.ReleaseDate) <= 0 THEN 1 ELSE Seasons - Year(serinf.ReleaseDate) END
			ELSE Seasons
		END
ORDER BY 2;