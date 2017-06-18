﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 15.0.0.0
//  
//     Änderungen an dieser Datei können fehlerhaftes Verhalten verursachen und gehen verloren, wenn
//     der Code neu generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace FPLedit.BuchfahrplanExport.Templates
{
    using FPLedit.Shared;
    using FPLedit.BuchfahrplanExport.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ZLBTemplate : ZLBTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
<!DOCTYPE html>
<html>
	<head>
		<meta charset=""utf-8"">
		<title>Buchfahrplan generiert von FPLedit</title>
		<style>
		table:not(.tfz-table) {
			border-collapse: collapse;
			table-layout:fixed;
			width:454pt;
			margin-left:auto;
			margin-right:auto;
			margin-bottom:65px;
		}
		body {
			font-family:");
            
            #line 20 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(", serif;\r\n\t\t}\r\n\t\ttable:not(.first) {\r\n\t\t\tpage-break-before:always;\r\n\t\t}\r\n\t\ttd {\r\n" +
                    "\t\t\tpadding-top:1px;\r\n\t\t\tpadding-right:1px;\r\n\t\t\tpadding-left:1px;\r\n\t\t\tcolor:black" +
                    ";\r\n\t\t\twhite-space:nowrap;\r\n\t\t\tfont-size:11.0pt;\r\n\t\t}\r\n\t\t.tfz {\r\n\t\t\tfont-weight:4" +
                    "00;\r\n\t\t\tvertical-align:bottom;\r\n\t\t\tpadding-bottom:30px;\r\n\t\t}\r\n\t\t.tfz-table {\r\n\t\t" +
                    "\twidth: 100%;\r\n\t\t}\r\n\t\t.tfz-table td {\r\n\t\t\twidth: 33%;\r\n\t\t}\r\n\t\t.tfz-table td:nth-" +
                    "child(2) {\r\n\t\t\ttext-align: center;\r\n\t\t}\r\n\t\t.tfz-table td:nth-child(3) {\r\n\t\t\ttext" +
                    "-align: right;\r\n\t\t}\r\n\t\t.trainname {\r\n\t\t\theight:19.5pt;\r\n\t\t\tfont-size:15.0pt;\r\n\t\t" +
                    "\tfont-weight:bold;\r\n\t\t\ttext-align:center;\r\n\t\t\tvertical-align:middle;\r\n\t\t}\r\n\t\t.li" +
                    "nename {\r\n\t\t\tfont-size:12.0pt;\r\n\t\t\tfont-weight:bold;\r\n\t\t\ttext-align:center;\r\n\t\t\t" +
                    "vertical-align:middle;\r\n\t\t}\r\n\t\t.spaltennummer {\r\n\t\t\tfont-weight:400;\r\n\t\t\ttext-al" +
                    "ign:center;\r\n\t\t\tvertical-align:top;\r\n\t\t\tborder:1.5pt solid black;\r\n\t\t\tborder-bot" +
                    "tom:.5pt solid black;\r\n\t\t\tborder-top:2.5pt solid black;\r\n\t\t}\r\n\t\t.spaltenkopf {\r\n" +
                    "\t\t\theight: 120px;\r\n\t\t\tfont-weight:400;\r\n\t\t\ttext-align:center;\r\n\t\t\tvertical-align" +
                    ":top;\r\n\t\t\tborder:1.5pt solid black;\r\n\t\t\tborder-top:.5pt solid black;\r\n\t\t}\r\n\t\t.kl" +
                    "ein {\r\n\t\t\tfont-size:0.7em;\r\n\t\t\twhite-space: normal;\r\n\t\t}\r\n\t\t.zug {\r\n\t\t\theight: 1" +
                    "9px;\r\n\t\t\tfont-weight:400;\r\n\t\t\ttext-align:center;\r\n\t\t\tvertical-align:top;\r\n\t\t\tbor" +
                    "der-right:1.5pt solid black;\r\n\t\t\tborder-left:1.5pt solid black;\r\n\t\t}\r\n\t\t.trapez-" +
                    "tt {\r\n\t\t\tborder: 1px solid black;\r\n\t\t\tpadding: 2px;\r\n\t\t}\r\n\t\ttd.first {\r\n\t\t\tborde" +
                    "r-left:none;\r\n\t\t}\r\n\t\ttd.last {\r\n\t\t\tborder-right:none;\r\n\t\t}\r\n\t\t@media print {\r\n\t\t" +
                    "\t@page {\r\n\t\t\t\tmargin: 0;\r\n\t\t\t}\r\n\t\t}\r\n\t\t</style>\r\n\t\t<style id=\"add-css\">\r\n\t\t\t");
            
            #line 108 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(additionalCss));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t</style>\r\n\t</head>\r\n\t<body>\r\n\t\t<div>\r\n\t\t\t");
            
            #line 113 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"

			bool first = true; // No pagebreak before first train
			foreach (Train tra in tt.Trains) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<table id=\"");
            
            #line 116 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.HtmlName(tra.TName, "train-")));
            
            #line default
            #line hidden
            this.Write("\" class=\"");
            
            #line 116 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(first ? "first" : ""));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t");
            
            #line 117 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 first = false; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<col style=\"width:50px;\">\r\n\t\t\t\t<col style=\"width:50px;\">\r\n\t\t\t\t<col style=\"wid" +
                    "th:200px;\">\r\n\t\t\t\t<col style=\"width:62px;\">\r\n\t\t\t\t<col style=\"width:50px;\">\r\n\t\t\t\t<" +
                    "col style=\"width:50px;\">\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colspan=9 class=\"trainname\">");
            
            #line 125 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tra.TName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colspan=9 class=\"linename\">");
            
            #line 128 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tt.GetLineName(tra.Direction)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td class=\"tfz\" colspan=\"9\">\r\n\t\t\t\t\t<table class=" +
                    "\"tfz-table\"><tr>\r\n\t\t\t\t\t<td>");
            
            #line 133 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OptAttr("Zlok", tra.Locomotive)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td>");
            
            #line 134 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OptAttr("Last", tra.Last)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td>");
            
            #line 135 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OptAttr("Mbr", tra.Mbr)));
            
            #line default
            #line hidden
            this.Write(@"</td>
					</tr></table>
					</td>
				</tr>
				<tr>
					<td class=""spaltennummer first"">1</td>
					<td class=""spaltennummer"">2</td>
					<td class=""spaltennummer"">3</td>
					<td class=""spaltennummer"">4</td>
					<td class=""spaltennummer"">5</td>
					<td class=""spaltennummer"">6</td>
					<td class=""spaltennummer"">7</td>
					<td class=""spaltennummer"">8</td>
					<td class=""spaltennummer last"">9</td>
				</tr>
				<tr>
					<td class=""spaltenkopf klein first"">Lage<br>der<br>Betriebs-<br>stelle<br><br>km</td>
					<td class=""spaltenkopf klein"">Höchst-<br>ge-<br>schwin-<br>digkeit<br><br>km/h</td>
					<td class=""spaltenkopf"">Betriebsstellen,<br>ständige Langsam-<br>fahrstellen,<br>verkürzter<br>Vorsignalabstand</td>
					<td class=""spaltenkopf klein"">An der<br>Trapeztafel<br>hält Zug</td>
					<td class=""spaltenkopf"">An-<br>kunft</td>
					<td class=""spaltenkopf"">Ab-<br>fahrt</td>
					<td class=""spaltenkopf klein"">Kreu-<br>zung<br>mit Zug</td>
					<td class=""spaltenkopf klein"">über-<br>holt<br>&mdash;<br>wird<br>über-<br>holt<br>durch<br>Zug</td>
					<td class=""spaltenkopf klein last"">Zuglauf-<br>meldung<br>durch</td>
				</tr>
				");
            
            #line 161 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 foreach (var entity in helper.GetStations(tra.Direction)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<tr class=\"");
            
            #line 162 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.HtmlName(entity.GetAttribute("name", ""), "station-")));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 163 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"

					if (entity.GetType() == typeof(Station)) {
						Station s = (Station)entity; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug first\">");
            
            #line 166 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.Kilometre.ToString("0.0")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 167 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.GetAttribute("fpl-vmax", "")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 168 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.SName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug klein\"><!--Trapeztafel-->");
            
            #line 169 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.TrapezHalt(tra, s)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t");
            
            #line 170 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"

					var ardp = tra.GetArrDep(s);
					var ar = ardp.Arrival.ToShortTimeString();
					var dp = ardp.Departure.ToShortTimeString();
					var zlm = ardp.Zuglaufmeldung;
					
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug\">");
            
            #line 176 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ar != "00:00" ? ar : ""));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 177 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dp != "00:00" ? dp : ""));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug klein\"><!--Kreuzung-->");
            
            #line 178 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.Kreuzt(tra, s)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug klein\"><!--überholt-->");
            
            #line 179 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.Ueberholt(tra, s)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug klein last\">");
            
            #line 180 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(zlm ?? ""));
            
            #line default
            #line hidden
            this.Write("<!--Zuglaufmeldung--></td>\r\n\r\n\t\t\t\t\t");
            
            #line 182 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 } else {
						BfplPoint p = (BfplPoint)entity; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug first\">");
            
            #line 184 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Kilometre.ToString("0.0")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 185 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.GetAttribute("fpl-vmax", "")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 186 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.PName));
            
            #line default
            #line hidden
            this.Write(@"</td>
					<td class=""zug klein""><!--Trapeztafel, bleibt mehr--></td>
					<td class=""zug""></td>
					<td class=""zug""></td>
					<td class=""zug klein""><!--Kreuzung, bleibt leer--></td>
					<td class=""zug klein""><!--überholt, bleibt leer--></td>
					<td class=""zug klein last""><!--Zuglaufmeldung--></td>
					");
            
            #line 193 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</tr>\r\n\t\t\t\t");
            
            #line 195 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t</table>\r\n\t\t\t");
            
            #line 197 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\Templates\ZLBTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t</div>\r\n\t</body>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class ZLBTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
