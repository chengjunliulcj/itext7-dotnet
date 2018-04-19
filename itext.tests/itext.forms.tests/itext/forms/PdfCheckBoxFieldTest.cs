using System;
using iText.Forms.Fields;
using iText.IO.Util;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Utils;
using iText.Test;

namespace iText.Forms {
    public class PdfCheckBoxFieldTest : ExtendedITextTest {
        public static readonly String destinationFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/forms/PdfCheckBoxFieldTest/";

        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/forms/PdfCheckBoxFieldTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateOrClearDestinationFolder(destinationFolder);
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxFontSizeTest01() {
            String outPdf = destinationFolder + "checkBoxFontSizeTest01.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxFontSizeTest01.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outPdf));
            pdfDoc.AddNewPage();
            AddCheckBox(pdfDoc, 6, 750, 7, 7);
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxFontSizeTest02() {
            String outPdf = destinationFolder + "checkBoxFontSizeTest02.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxFontSizeTest02.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outPdf));
            pdfDoc.AddNewPage();
            AddCheckBox(pdfDoc, 0, 730, 7, 7);
            AddCheckBox(pdfDoc, -1, 710, 7, 7);
            AddCheckBox(pdfDoc, 0, 640, 20, 20);
            AddCheckBox(pdfDoc, 0, 600, 40, 20);
            AddCheckBox(pdfDoc, 0, 550, 20, 40);
            AddCheckBox(pdfDoc, 0, 520, 5, 5);
            AddCheckBox(pdfDoc, 0, 510, 5, 3);
            AddCheckBox(pdfDoc, 0, 500, 3, 5);
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxFontSizeTest03() {
            String outPdf = destinationFolder + "checkBoxFontSizeTest03.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxFontSizeTest03.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outPdf));
            pdfDoc.AddNewPage();
            AddCheckBox(pdfDoc, 2, 730, 7, 7);
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxFontSizeTest04() {
            String outPdf = destinationFolder + "checkBoxFontSizeTest04.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxFontSizeTest04.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outPdf));
            pdfDoc.AddNewPage();
            AddCheckBox(pdfDoc, 0, 730, 10, PdfFormField.CreateCheckBox(pdfDoc, new Rectangle(50, 730, 10, 10), "cb_1"
                , "YES", PdfFormField.TYPE_CIRCLE));
            AddCheckBox(pdfDoc, 0, 700, 10, PdfFormField.CreateCheckBox(pdfDoc, new Rectangle(50, 700, 10, 10), "cb_2"
                , "YES", PdfFormField.TYPE_CROSS));
            AddCheckBox(pdfDoc, 0, 670, 10, PdfFormField.CreateCheckBox(pdfDoc, new Rectangle(50, 670, 10, 10), "cb_3"
                , "YES", PdfFormField.TYPE_DIAMOND));
            AddCheckBox(pdfDoc, 0, 640, 10, PdfFormField.CreateCheckBox(pdfDoc, new Rectangle(50, 640, 10, 10), "cb_4"
                , "YES", PdfFormField.TYPE_SQUARE));
            AddCheckBox(pdfDoc, 0, 610, 10, PdfFormField.CreateCheckBox(pdfDoc, new Rectangle(50, 610, 10, 10), "cb_5"
                , "YES", PdfFormField.TYPE_STAR));
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxFontSizeTest05() {
            String outPdf = destinationFolder + "checkBoxFontSizeTest05.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxFontSizeTest05.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outPdf));
            pdfDoc.AddNewPage();
            AddCheckBox(pdfDoc, 0, 730, 40, 40);
            AddCheckBox(pdfDoc, 0, 600, 100, 100);
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxToggleTest01() {
            String srcPdf = sourceFolder + "checkBoxToggledOn.pdf";
            String outPdf = destinationFolder + "checkBoxToggleTest01.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxToggleTest01.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(srcPdf), new PdfWriter(outPdf));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            PdfFormField checkBox = form.GetField("cb_fs_6_7_7");
            checkBox.SetValue("Off");
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void CheckBoxToggleTest02() {
            String srcPdf = sourceFolder + "checkBoxToggledOn.pdf";
            String outPdf = destinationFolder + "checkBoxToggleTest02.pdf";
            String cmpPdf = sourceFolder + "cmp_checkBoxToggleTest02.pdf";
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(srcPdf), new PdfWriter(outPdf));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            PdfFormField checkBox = form.GetField("cb_fs_6_7_7");
            checkBox.SetValue("Off", false);
            pdfDoc.Close();
            CompareTool compareTool = new CompareTool();
            String errorMessage = compareTool.CompareByContent(outPdf, cmpPdf, destinationFolder, "diff_");
            if (errorMessage != null) {
                NUnit.Framework.Assert.Fail(errorMessage);
            }
        }

        /// <exception cref="System.IO.IOException"/>
        private void AddCheckBox(PdfDocument pdfDoc, float fontSize, float yPos, float checkBoxW, float checkBoxH) {
            Rectangle rect = new Rectangle(50, yPos, checkBoxW, checkBoxH);
            AddCheckBox(pdfDoc, fontSize, yPos, checkBoxW, PdfFormField.CreateCheckBox(pdfDoc, rect, MessageFormatUtil
                .Format("cb_fs_{0}_{1}_{2}", fontSize, checkBoxW, checkBoxH), "YES", PdfFormField.TYPE_CHECK));
        }

        /// <exception cref="System.IO.IOException"/>
        private void AddCheckBox(PdfDocument pdfDoc, float fontSize, float yPos, float checkBoxW, PdfFormField checkBox
            ) {
            PdfPage page = pdfDoc.GetFirstPage();
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            if (fontSize >= 0) {
                checkBox.SetFontSize(fontSize);
            }
            checkBox.SetBorderWidth(1);
            checkBox.SetBorderColor(ColorConstants.BLACK);
            form.AddField(checkBox, page);
            PdfCanvas canvas = new PdfCanvas(page);
            canvas.SaveState().BeginText().MoveText(50 + checkBoxW + 10, yPos).SetFontAndSize(PdfFontFactory.CreateFont
                (), 12).ShowText("okay?").EndText().RestoreState();
        }
    }
}