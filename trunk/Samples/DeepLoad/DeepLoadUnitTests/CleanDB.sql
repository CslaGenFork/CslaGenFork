DELETE FROM [6_CityRoads] WHERE [6_CityRoads].CityRoad_ID > 81;
DBCC CHECKIDENT ([6_CityRoads], RESEED, 81);

DELETE FROM [5_Cities_Child] WHERE [5_Cities_Child].City_ID1 > 27;
DELETE FROM [5_Cities_ReChild] WHERE [5_Cities_ReChild].City_ID2 > 27;
DELETE FROM [5_Cities] WHERE [5_Cities].City_ID > 27;
DBCC CHECKIDENT ([5_Cities], RESEED, 27);

DELETE FROM [4_Regions_Child] WHERE [4_Regions_Child].Region_ID1 > 27;
DELETE FROM [4_Regions_ReChild] WHERE [4_Regions_ReChild].Region_ID2 > 27;
DELETE FROM [4_Regions] WHERE [4_Regions].Region_ID > 27;
DBCC CHECKIDENT ([4_Regions], RESEED, 27);

DELETE FROM [3_Countries_Child] WHERE [3_Countries_Child].Country_ID1 > 9;
DELETE FROM [3_Countries_ReChild] WHERE [3_Countries_ReChild].Country_ID2 > 9;
DELETE FROM [3_Countries] WHERE [3_Countries].Country_ID > 9;
DBCC CHECKIDENT ([3_Countries], RESEED, 9);

DELETE FROM [2_SubContinents_Child] WHERE [2_SubContinents_Child].SubContinent_ID1 > 6;
DELETE FROM [2_SubContinents_ReChild] WHERE [2_SubContinents_ReChild].SubContinent_ID2 > 6;
DELETE FROM [2_SubContinents] WHERE [2_SubContinents].SubContinent_ID > 6;
DBCC CHECKIDENT ([2_SubContinents], RESEED, 6);

DELETE FROM [1_Continents_Child] WHERE [1_Continents_Child].Continent_ID1 > 3;
DELETE FROM [1_Continents_ReChild] WHERE [1_Continents_ReChild].Continent_ID2 > 3;
DELETE FROM [1_Continents] WHERE [1_Continents].Continent_ID > 3;
DBCC CHECKIDENT ([1_Continents], RESEED, 3);

DELETE FROM [Dummy_Level_1_1_1_2] WHERE [Dummy_Level_1_1_1_2].Level_1_1_1_2_ID > 27;
DBCC CHECKIDENT ([Dummy_Level_1_1_1_2], RESEED, 27);

DELETE FROM [Dummy_Level_1_1_2] WHERE [Dummy_Level_1_1_2].Level_1_1_2_ID > 9;
DBCC CHECKIDENT ([Dummy_Level_1_1_2], RESEED, 9);

DELETE FROM [Dummy_Level_1_2] WHERE [Dummy_Level_1_2].Level_1_2_ID > 6;
DBCC CHECKIDENT ([Dummy_Level_1_2], RESEED, 6);
