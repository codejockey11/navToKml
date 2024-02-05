DEL nav*.kml

DEL navToKml.txt

mysql.exe --login-path=batch --table < navToKml.sql

navToKml.exe navToKml.txt

DEL navToKml.txt

REM SET GDAL_DATA=C:\\Program Files\\QGIS 3.22.1\\apps\\gdal-dev\\data
REM SET GDAL_DRIVER_PATH=C:\\Program Files\\QGIS 3.22.1\\bin\\gdalplugins
REM SET OSGEO4W_ROOT=C:\\Program Files\\QGIS 3.22.1
REM SET PATH=%OSGEO4W_ROOT%\\bin;%PATH%
REM SET PYTHONHOME=%OSGEO4W_ROOT%\\apps\\Python37
REM SET PYTHONPATH=%OSGEO4W_ROOT%\\apps\\Python37

REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\dme.shp" "dme.kml" dme
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\ndb.shp" "ndb.kml" ndb
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\vor.shp" "vor.kml" vor
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\vordme.shp" "vordme.kml" vordme
REM ogr2ogr.exe -f "ESRI Shapefile" -skipfailures "shape\\vortac.shp" "vortac.kml" vortac
