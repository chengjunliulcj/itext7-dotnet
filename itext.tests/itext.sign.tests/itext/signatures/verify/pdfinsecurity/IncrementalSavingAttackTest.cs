/*
This file is part of the iText (R) project.
Copyright (c) 1998-2019 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Signatures;
using iText.Test;
using iText.Test.Attributes;

namespace iText.Signatures.Verify.Pdfinsecurity {
    public class IncrementalSavingAttackTest : ExtendedITextTest {
        private static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/signatures/verify/pdfinsecurity/IncrementalSavingAttackTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void Before() {
        }

        [NUnit.Framework.Test]
        [LogMessage(iText.IO.LogMessageConstant.XREF_ERROR)]
        public virtual void TestISA03() {
            String filePath = sourceFolder + "isa-3.pdf";
            String signatureName = "Signature1";
            PdfDocument document = new PdfDocument(new PdfReader(filePath));
            SignatureUtil sigUtil = new SignatureUtil(document);
            PdfPKCS7 pdfPKCS7 = sigUtil.ReadSignatureData(signatureName);
            NUnit.Framework.Assert.IsTrue(pdfPKCS7.VerifySignatureIntegrityAndAuthenticity());
            NUnit.Framework.Assert.IsFalse(sigUtil.SignatureCoversWholeDocument(signatureName));
            document.Close();
        }

        [NUnit.Framework.Test]
        public virtual void TestISAValidPdf() {
            String filePath = sourceFolder + "isaValidPdf.pdf";
            String signatureName = "Signature1";
            PdfDocument document = new PdfDocument(new PdfReader(filePath));
            SignatureUtil sigUtil = new SignatureUtil(document);
            PdfPKCS7 pdfPKCS7 = sigUtil.ReadSignatureData(signatureName);
            NUnit.Framework.Assert.IsTrue(pdfPKCS7.VerifySignatureIntegrityAndAuthenticity());
            NUnit.Framework.Assert.IsFalse(sigUtil.SignatureCoversWholeDocument(signatureName));
            String textFromPage = PdfTextExtractor.GetTextFromPage(document.GetPage(1));
            // We are working with the latest revision of the document, that's why we should get amended page text.
            // However Signature shall be marked as not covering the complete document, indicating its invalidity
            // for the current revision.
            NUnit.Framework.Assert.AreEqual("This is manipulated malicious text, ha-ha!", textFromPage);
            NUnit.Framework.Assert.AreEqual(2, sigUtil.GetTotalRevisions());
            NUnit.Framework.Assert.AreEqual(1, sigUtil.GetRevision(signatureName));
            Stream sigInputStream = sigUtil.ExtractRevision(signatureName);
            PdfDocument sigRevDocument = new PdfDocument(new PdfReader(sigInputStream));
            SignatureUtil sigRevUtil = new SignatureUtil(sigRevDocument);
            PdfPKCS7 sigRevSignatureData = sigRevUtil.ReadSignatureData(signatureName);
            NUnit.Framework.Assert.IsTrue(sigRevSignatureData.VerifySignatureIntegrityAndAuthenticity());
            NUnit.Framework.Assert.IsTrue(sigRevUtil.SignatureCoversWholeDocument(signatureName));
            sigRevDocument.Close();
            document.Close();
        }
    }
}
