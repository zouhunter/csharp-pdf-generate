﻿using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{
    public class Chap1005
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 10 example 5: Simple Columns");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1005.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4:

                // we create some content
                BaseFont bf = BaseFont.createFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font font = new Font(bf, 11, Font.NORMAL);

                Phrase unicodes = new Phrase(15, "UNI\n", font);
                Phrase characters = new Phrase(15, "\n", font);
                Phrase names = new Phrase(15, "NAME\n", font);

                for (int i = 0; i < 27; i++)
                {
                    unicodes.Add(uni[i] + "\n");
                    characters.Add(code[i] + "\n");
                    names.Add(name[i] + "\n");
                }

                // we grab the ContentByte and do some stuff with it
                PdfContentByte cb = writer.DirectContent;

                ColumnText ct = new ColumnText(cb);
                ct.setSimpleColumn(unicodes, 60, 300, 100, 300 + 28 * 15, 15, Element.ALIGN_CENTER);
                ct.go();
                cb.rectangle(103, 295, 52, 8 + 28 * 15);
                cb.stroke();
                ct.setSimpleColumn(characters, 105, 300, 150, 300 + 28 * 15, 15, Element.ALIGN_RIGHT);
                ct.go();
                ct.setSimpleColumn(names, 160, 300, 500, 300 + 28 * 15, 15, Element.ALIGN_LEFT);
                ct.go();

            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }

            // step 5: we close the document
            document.Close();

            System.Diagnostics.Process.Start("Chap1005.pdf");
        }

        public static String[] uni = new String[27];
        public static String[] code = new String[27];
        public static String[] name = new String[27];

        static Chap1005()
        {
            uni[0] = "\\u0152";
            code[0] = "\u0152";
            name[0] = "LATIN CAPITAL LIGATURE OE";

            uni[1] = "\\u0153";
            code[1] = "\u0153";
            name[1] = "LATIN SMALL LIGATURE OE";

            uni[2] = "\\u0160";
            code[2] = "\u0160";
            name[2] = "LATIN CAPITAL LETTER S WITH CARON";

            uni[3] = "\\u0161";
            code[3] = "\u0161";
            name[3] = "LATIN SMALL LETTER S WITH CARON";

            uni[4] = "\\u0178";
            code[4] = "\u0178";
            name[4] = "LATIN CAPITAL LETTER Y WITH DIAERESIS";

            uni[5] = "\\u017D";
            code[5] = "\u017D";
            name[5] = "LATIN CAPITAL LETTER Z WITH CARON";

            uni[6] = "\\u017E";
            code[6] = "\u017E";
            name[6] = "LATIN SMALL LETTER Z WITH CARON";

            uni[7] = "\\u0192";
            code[7] = "\u0192";
            name[7] = "LATIN SMALL LETTER F WITH HOOK";

            uni[8] = "\\u02C6";
            code[8] = "\u02C6";
            name[8] = "MODIFIER LETTER CIRCUMFLEX ACCENT";

            uni[9] = "\\u02DC";
            code[9] = "\u02DC";
            name[9] = "SMALL TILDE";

            uni[10] = "\\u2013";
            code[10] = "\u2013";
            name[10] = "EN DASH";

            uni[11] = "\\u2014";
            code[11] = "\u2014";
            name[11] = "EM DASH";

            uni[12] = "\\u2018";
            code[12] = "\u2018";
            name[12] = "LEFT SINGLE QUOTATION MARK";

            uni[13] = "\\u2019";
            code[13] = "\u2019";
            name[13] = "RIGHT SINGLE QUOTATION MARK";

            uni[14] = "\\u201A";
            code[14] = "\u201A";
            name[14] = "SINGLE LOW-9 QUOTATION MARK";

            uni[15] = "\\u201C";
            code[15] = "\u201C";
            name[15] = "LEFT DOUBLE QUOTATION MARK";

            uni[16] = "\\u201D";
            code[16] = "\u201D";
            name[16] = "RIGHT DOUBLE QUOTATION MARK";

            uni[17] = "\\u201E";
            code[17] = "\u201E";
            name[17] = "DOUBLE LOW-9 QUOTATION MARK";

            uni[18] = "\\u2020";
            code[18] = "\u2020";
            name[18] = "DAGGER";

            uni[19] = "\\u2021";
            code[19] = "\u2021";
            name[19] = "DOUBLE DAGGER";

            uni[20] = "\\u2022";
            code[20] = "\u2022";
            name[20] = "BULLET";

            uni[21] = "\\u2026";
            code[21] = "\u2026";
            name[21] = "HORIZONTAL ELLIPSIS";

            uni[22] = "\\u2030";
            code[22] = "\u2030";
            name[22] = "PER MILLE SIGN";

            uni[23] = "\\u2039";
            code[23] = "\u2039";
            name[23] = "SINGLE LEFT-POINTING ANGLE QUOTATION MARK";

            uni[24] = "\\u203A";
            code[24] = "\u203A";
            name[24] = "SINGLE RIGHT-POINTING ANGLE QUOTATION MARK";

            uni[25] = "\\u20AC";
            code[25] = "\u20AC";
            name[25] = "EURO SIGN";

            uni[26] = "\\u2122";
            code[26] = "\u2122";
            name[26] = "TRADE MARK SIGN";
        }
    }

}