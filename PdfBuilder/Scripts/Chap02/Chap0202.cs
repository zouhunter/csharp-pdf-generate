﻿using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap02
{
    public class Chap0201
    {
        public static void Main()
        {

            Console.WriteLine("Chapter 2 example 1: Chunks and fonts");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0201.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we Add content to the document
                Font[] fonts = new Font[14];
                fonts[0] = FontFactory.getFont(FontFactory.COURIER, 12, Font.NORMAL);
                fonts[1] = FontFactory.getFont(FontFactory.COURIER, 12, Font.BOLD);
                fonts[2] = FontFactory.getFont(FontFactory.COURIER, 12, Font.ITALIC);
                fonts[3] = FontFactory.getFont(FontFactory.COURIER, 12, Font.BOLD | Font.ITALIC);
                fonts[4] = FontFactory.getFont(FontFactory.HELVETICA, 12, Font.NORMAL);
                fonts[5] = FontFactory.getFont(FontFactory.HELVETICA, 12, Font.BOLD);
                fonts[6] = FontFactory.getFont(FontFactory.HELVETICA, 12, Font.ITALIC);
                fonts[7] = FontFactory.getFont(FontFactory.HELVETICA, 12, Font.BOLD | Font.ITALIC);
                fonts[8] = FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 12, Font.NORMAL);
                fonts[9] = FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 12, Font.BOLD);
                fonts[10] = FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 12, Font.ITALIC);
                fonts[11] = FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 12, Font.BOLD | Font.ITALIC);
                fonts[12] = FontFactory.getFont(FontFactory.SYMBOL, 12, Font.NORMAL);
                fonts[13] = FontFactory.getFont(FontFactory.ZAPFDINGBATS, 12, Font.NORMAL);
                for (int i = 0; i < 14; i++)
                {
                    Chunk chunk = new Chunk("This is some", fonts[i]);
                    document.Add(new Phrase(chunk));
                    document.Add(new Phrase(new Chunk(" font. ",
                        fonts[i]).setTextRise((i % 2 == 0) ? -6 : 6)));
                }
                document.Add(new Phrase(new Chunk("This text is underlined",
                    FontFactory.getFont(FontFactory.HELVETICA, 12, Font.UNDERLINE))));
                document.Add(new Phrase(new Chunk("This font is of type ITALIC | STRIKETHRU",
                    FontFactory.getFont(FontFactory.HELVETICA, 12, Font.ITALIC | Font.STRIKETHRU))));
                Chunk ck = new Chunk("This text has a yellow background color", FontFactory.getFont(FontFactory.HELVETICA, 12));
                ck.setBackground(new Color(0xFF, 0xFF, 0x00));
                document.Add(new Phrase(ck));
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

            System.Diagnostics.Process.Start("Chap0202.pdf");
        }
    }
}

