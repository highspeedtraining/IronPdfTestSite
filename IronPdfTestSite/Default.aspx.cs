using IronPdf;
using System;
using System.Web.UI;

namespace IronPdfTestSite
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lb_getPDF_OnClick(object sender, EventArgs e)
		{
			var htmlToPdf = new HtmlToPdf();

			var pdfDocument = htmlToPdf.RenderHtmlAsPdf("<html><body><div>Hello World</div></body></html>");
			var pdfDocumentBinaryData = pdfDocument.BinaryData;

			Response.Clear();
			Response.AddHeader("Content-Type", "binary/octet-stream");
			Response.AddHeader("Content-Disposition", $"attachment; filename=\"test.pdf\"; size={pdfDocumentBinaryData.Length}");
			Response.BinaryWrite(pdfDocumentBinaryData);
		}
	}
}