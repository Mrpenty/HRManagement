using HRManagement.Data.Entity;
using Microsoft.Extensions.Logging;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using HRManagement.Business.dtos.Payslip;

namespace HRManagement.Business.Repositories.impl
{
    public class PdfGeneratorRepository : IPdfGeneratorRepository
    {
        private readonly IPaySlipRepository _paySlipRepository;
        private readonly ILogger<PdfGeneratorRepository> _logger;
        private readonly PdfFont _boldFont;
        private readonly PdfFont _regularFont;

        public PdfGeneratorRepository(IPaySlipRepository paySlipRepository, ILogger<PdfGeneratorRepository> logger)
        {
            _paySlipRepository = paySlipRepository;
            _logger = logger;

            _boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            _regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        }

        public Task GeneratePaySlipPdfAsync(PaySlipGet payslipDto, string filePath)
        {
            try
            {
                using var writer = new PdfWriter(filePath);
                using var pdf = new PdfDocument(writer);
                using var document = new Document(pdf);

                AddHeader(document, payslipDto);
                AddEmployeeInfo(document, payslipDto);
                AddSalaryDetails(document, payslipDto);
                AddSummary(document, payslipDto);
                AddFooter(document, payslipDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating PDF for payslip {PaySlipId}", payslipDto.PayslipID);
                throw;
            }

            return Task.CompletedTask;
        }

        private void AddHeader(Document doc, PaySlipGet payslipDto)
        {
            var header = new Paragraph("PAYSLIP")
                .SetFont(_boldFont)
                .SetFontSize(24)
                .SetFontColor(ColorConstants.BLUE);

            doc.Add(header);
            doc.Add(new Paragraph($"Payslip #: {payslipDto.PayslipID}").SetFont(_regularFont));
            doc.Add(new Paragraph($"Issue Date: {payslipDto.IssueDate:dd/MM/yyyy}").SetFont(_regularFont));
        }

        private void AddEmployeeInfo(Document doc, PaySlipGet payslipDto)
        {
            doc.Add(new Paragraph("Employee Information").SetFont(_boldFont).SetFontSize(16));

            var table = new Table(2).UseAllAvailableWidth();

            AddRow(table, "Employee ID", payslipDto.UserID.ToString());
            AddRow(table, "Name", $"{payslipDto.UserName}");
            AddRow(table, "Email", payslipDto.Email ?? "N/A");
            AddRow(table, "Department", payslipDto.DepartmentName ?? "N/A");
            AddRow(table, "Position", payslipDto.PositionName ?? "N/A");

            doc.Add(table);
        }

        private void AddSalaryDetails(Document doc, PaySlipGet payslipDto)
        {
            doc.Add(new Paragraph("Salary Details").SetFont(_boldFont).SetFontSize(16));

            var table = new Table(2).UseAllAvailableWidth();

            var baseSalary = payslipDto.BaseSalary;
            var allowances = payslipDto.Allowances;
            var bonus = payslipDto.Bonus;

            AddRow(table, "Base Salary", baseSalary.ToString("C2"));
            AddRow(table, "Allowances", allowances.ToString("C2"));
            AddRow(table, "Bonus", bonus.ToString("C2"));

            doc.Add(table);
        }

        private void AddSummary(Document doc, PaySlipGet payslipDto)
        {
            decimal baseSalary = payslipDto.BaseSalary;
            decimal allowances = payslipDto.Allowances;
            decimal bonus = payslipDto.Bonus;

            decimal total = baseSalary + allowances + bonus;

            doc.Add(new Paragraph("Summary").SetFont(_boldFont).SetFontSize(16));

            var table = new Table(2).UseAllAvailableWidth();
            AddRow(table, "Gross Pay", total.ToString("C2"));
            AddRow(table, "Net Pay", total.ToString("C2"));

            doc.Add(table);
        }

        private void AddFooter(Document doc, PaySlipGet payslipDto)
        {
            var footer = new Paragraph($"Generated on {DateTime.Now:dd/MM/yyyy HH:mm} | Status: {payslipDto.Status}")
                .SetFont(_regularFont)
                .SetFontSize(10)
                .SetFontColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER);

            doc.Add(footer);
        }

        private void AddRow(Table table, string label, string value)
        {
            table.AddCell(new Cell().Add(new Paragraph(label).SetFont(_boldFont)));
            table.AddCell(new Cell().Add(new Paragraph(value).SetFont(_regularFont)));
        }
    }
}
