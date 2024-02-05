using System;
using System.IO;
using aviationLib;

namespace navToKml
{
    class Program
    {
        static StreamReader rowset;
        static String row;
        static String[] columns;

        static String facility;
        static String freq;
        static String name;

        static StreamWriter navNdb;
        static StreamWriter navVor;
        static StreamWriter navVorDme;
        static StreamWriter navVortac;
        static StreamWriter navDme;
        static StreamWriter navTacan;
        static StreamWriter navNdbDme;
        static StreamWriter navVot;

        static LatLon latLon;

        static void WriteKml(StreamWriter sw)
        {
            sw.WriteLine("\t<Placemark>");
            sw.WriteLine("\t\t<name>" + facility + ":" + name + ":" + freq + "</name>");
            sw.WriteLine("\t\t<Point>");
            sw.WriteLine("\t\t\t<coordinates>");

            sw.WriteLine("\t\t\t\t" + latLon.decimalLon.ToString("F6") + "," + latLon.decimalLat.ToString("F6"));

            sw.WriteLine("\t\t\t</coordinates>");
            sw.WriteLine("\t\t</Point>");
            sw.WriteLine("\t</Placemark>");
        }

        static StreamWriter InitNewWriter(String name)
        {
            StreamWriter writer = new StreamWriter(name);

            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            writer.WriteLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
            writer.WriteLine("<Document>");

            return writer;
        }

        static void CloseWriter(StreamWriter writer)
        {
            writer.WriteLine("</Document>");
            writer.WriteLine("</kml>");

            writer.Close();
        }

        static void ProcessRow(String row)
        {
            columns = row.Split('~');

            facility = columns[1];

            freq = columns[4];

            latLon = new LatLon(columns[19], columns[20]);

            name = columns[11];


            switch (columns[3])
            {
            case "NDB":
            {
                WriteKml(navNdb);

                break;
            }

            case "VOR":
            {
                WriteKml(navVor);

                break;
            }

            case "VOR/DME":
            {
                WriteKml(navVorDme);

                break;
            }

            case "VORTAC":
            {
                WriteKml(navVortac);

                break;
            }

            case "DME":
            {
                WriteKml(navDme);

                break;
            }

            case "TACAN":
            {
                WriteKml(navTacan);

                break;
            }

            case "NDB/DME":
            {
                WriteKml(navNdbDme);

                break;
            }

            case "VOT":
            {
                WriteKml(navVot);

                break;
            }

            default:
            {
                Console.WriteLine("Unhandled Type:" + columns[3]); 

                break;
            }

            }
        }

        static void Main(string[] args)
        {
            rowset = new StreamReader(args[0]);

            navNdb = InitNewWriter("navNdb.kml");
            navVor = InitNewWriter("navVor.kml");
            navVorDme = InitNewWriter("navVorDme.kml");
            navVortac = InitNewWriter("navVortac.kml");
            navDme = InitNewWriter("navDme.kml");
            navTacan = InitNewWriter("navTacan.kml");
            navNdbDme = InitNewWriter("navNdbDme.kml");
            navVot = InitNewWriter("navVot.kml");


            row = rowset.ReadLine();

            while (!rowset.EndOfStream)
            {
                ProcessRow(row);

                row = rowset.ReadLine();
            }

            ProcessRow(row);


            CloseWriter(navNdb);
            CloseWriter(navVor);
            CloseWriter(navVorDme);
            CloseWriter(navVortac);
            CloseWriter(navDme);
            CloseWriter(navTacan);
            CloseWriter(navNdbDme);
            CloseWriter(navVot);

            rowset.Close();

        }
    }
}
