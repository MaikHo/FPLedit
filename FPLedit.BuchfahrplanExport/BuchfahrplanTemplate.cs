﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 15.0.0.0
//  
//     Änderungen an dieser Datei können fehlerhaftes Verhalten verursachen und gehen verloren, wenn
//     der Code neu generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace FPLedit.BuchfahrplanExport
{
    using FPLedit.Shared;
    using FPLedit.BuchfahrplanExport.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class BuchfahrplanTemplate : BuchfahrplanTemplateBase
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
		table {
			border-collapse: collapse;
			table-layout:fixed;
			width:454pt;
			margin-left:auto;
			margin-right:auto;
			margin-bottom:65px;
		}
		table:not(.first) {
			page-break-before:always;
		}
		td {
			padding-top:1px;
			padding-right:1px;
			padding-left:1px;
			color:black;
			white-space:nowrap;
			font-size:11.0pt;
		}
		.tfz {
			font-weight:400;
			font-style:normal;
			font-family:");
            
            #line 33 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(", sans-serif;\r\n\t\t\ttext-align:general;\r\n\t\t\tvertical-align:bottom;\r\n\t\t}\r\n\t\t.trainna" +
                    "me {\r\n\t\t\theight:19.5pt;\r\n\t\t\tfont-size:15.0pt;\r\n\t\t\tfont-weight:400;\r\n\t\t\tfont-styl" +
                    "e:normal;\r\n\t\t\tfont-family:");
            
            #line 42 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(", sans-serif;\r\n\t\t\ttext-align:center;\r\n\t\t\tvertical-align:middle;\r\n\t\t}\r\n\t\t.linename" +
                    " {\r\n\t\t\tfont-size:12.0pt;\r\n\t\t\tfont-weight:400;\r\n\t\t\tfont-style:normal;\r\n\t\t\tfont-fa" +
                    "mily:");
            
            #line 50 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(", sans-serif;\r\n\t\t\ttext-align:center;\r\n\t\t\tvertical-align:middle;\r\n\t\t}\r\n\t\t.spaltenn" +
                    "ummer {\r\n\t\t\tfont-weight:400;\r\n\t\t\tfont-style:normal;\r\n\t\t\tfont-family:");
            
            #line 57 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(@", sans-serif;
			text-align:center;
			vertical-align:top;
			border-top:1.5pt solid black;
			border-right:1.5pt solid black;
			border-bottom:.5pt solid black;
			border-left:1.5pt solid black;
		}
		.spaltenkopf {
			height: 130px;
			font-weight:400;
			font-style:normal;
			font-family:");
            
            #line 69 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(@", sans-serif;
			text-align:center;
			vertical-align:top;
			border-top:.5pt solid black;
			border-right:1.5pt solid black;
			border-bottom:1.5pt solid black;
			border-left:1.5pt solid black;
		}
		.zug {
			height: 19px;
			font-weight:400;
			font-style:normal;
			font-family:");
            
            #line 81 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(font));
            
            #line default
            #line hidden
            this.Write(@", sans-serif;
			text-align:center;
			vertical-align:top;
			border-right:1.5pt solid black;
			border-left:1.5pt solid black;
		}
		.tabellenende {
			height: 18px;
			border-right:1.5pt solid black;
			border-bottom:1.5pt solid black;
			border-left:1.5pt solid black;
		}
		@media print {
			@page {
				margin: 0;
			}
		}
		</style>
		<style id=""add-css"">
			");
            
            #line 100 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(additionalCss));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t</style>\r\n\t</head>\r\n\t<body>\r\n\t\t<div>\r\n\t\t\t");
            
            #line 105 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"

			bool first = true; // No pagebreak before first train
			foreach (Train tra in tt.Trains) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<table id=\"");
            
            #line 108 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HtmlName(tra.TName, "train-")));
            
            #line default
            #line hidden
            this.Write("\" class=\"");
            
            #line 108 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(first ? "first" : ""));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t");
            
            #line 109 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
 first = false; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<col style=\"width:80px;\" span=2>\r\n\t\t\t\t<col style=\"width:285px;\">\r\n\t\t\t\t<col st" +
                    "yle=\"width:80px;\" span=2>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colspan=5 class=\"trainname\">");
            
            #line 114 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tra.TName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colspan=5 class=\"linename\">");
            
            #line 117 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tt.GetLineName(tra.Direction)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td class=tfz>Tfz ");
            
            #line 120 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tra.Locomotive));
            
            #line default
            #line hidden
            this.Write(@"</td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td class=""spaltennummer"">0</td>
					<td class=""spaltennummer"">1</td>
					<td class=""spaltennummer"">2</td>
					<td class=""spaltennummer"">3</td>
					<td class=""spaltennummer"">4</td>
				</tr>
				<tr>
					<td class=""spaltenkopf"">Lage<br>der<br>Betriebs-<br>stelle<br><br>(km)</td>
					<td class=""spaltenkopf"">Höchst-<br>Geschwin-<br>digkeit<br><br><br>(km/h)</td>
					<td class=""spaltenkopf"">Betriebsstellen,<br>ständige Langsamfahrstellen,<br>verkürzter Vorsignalabstand</td>
					<td class=""spaltenkopf"">Ankunft</td><td class=spaltenkopf>Abfahrt<br>oder Durch-<br>fahrt</td>
				</tr>
				");
            
            #line 139 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
 foreach (var entity in GetStations(tra.Direction)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<tr class=\"");
            
            #line 140 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HtmlName(entity.GetAttribute("name", ""), "station-")));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 141 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"

					if (entity.GetType() == typeof(Station)) {
						Station s = (Station)entity; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug\">");
            
            #line 144 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.Kilometre.ToString("0.0")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 145 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.GetAttribute("fpl-vmax", "")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 146 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(s.SName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t");
            
            #line 147 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"

					var ardp = tra.GetArrDep(s);
					var ar = ardp.Arrival.ToShortTimeString();
					var dp = ardp.Departure.ToShortTimeString();
					
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug\">");
            
            #line 152 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ar != "00:00" ? ar : ""));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 153 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dp != "00:00" ? dp : ""));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\r\n\t\t\t\t\t");
            
            #line 155 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
 } else {
						BFPL_Point p = (BFPL_Point)entity; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<td class=\"zug\">");
            
            #line 157 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Kilometre.ToString("0.0")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 158 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.GetAttribute("fpl-vmax", "")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\">");
            
            #line 159 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.PName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t\t<td class=\"zug\"></td>\r\n\t\t\t\t\t<td class=\"zug\"></td>\r\n\t\t\t\t\t");
            
            #line 162 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</tr>\r\n\t\t\t\t");
            
            #line 164 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<tr>\r\n\t\t\t\t\t<td class=\"tabellenende\"></td>\r\n\t\t\t\t\t<td class=\"tabellenende\"></td" +
                    ">\r\n\t\t\t\t\t<td class=\"tabellenende\"></td>\r\n\t\t\t\t\t<td class=\"tabellenende\"></td>\r\n\t\t\t" +
                    "\t\t<td class=\"tabellenende\"></td>\r\n\t\t\t\t</tr>\r\n\t\t\t</table>\r\n\t\t\t");
            
            #line 173 "F:\VS-Projects\Buchfahrplan\Buchfahrplan\FPLedit.BuchfahrplanExport\BuchfahrplanTemplate.tt"
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
    public class BuchfahrplanTemplateBase
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
