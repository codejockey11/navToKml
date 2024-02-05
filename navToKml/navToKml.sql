USE aviation;

SELECT *
	INTO OUTFILE 'C:\\Users\\junk_\\Documents\\qgisBatch\\navToKml.txt' FIELDS TERMINATED BY '~' LINES TERMINATED BY '\r\n'
	FROM navNavaid
	WHERE type!='FAN MARKER';
	