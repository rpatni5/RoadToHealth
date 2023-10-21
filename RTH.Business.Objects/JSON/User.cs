﻿using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Security;

namespace RTH.Business.Objects
{
    public class ScoreHistory
    {
        public double total_score { get; set; }
        public double optimum_score { get; set; }
        public string date { get; set; }
        public string _id { get; set; }
        public List<object> sub_diseases { get; set; }
        public string questionnaire { get; set; }
    }


    public partial class Answer : NotifyBase
    {
        private const decimal stlbToKg = 6.350293m;
        private const decimal lbToKg = 0.453592m;
        private const decimal cmToFt = 0.032808m;
        private const decimal ftToCm = 30.48m;
        private const decimal inchesToFt = 0.083333m;
        private const decimal CmToInch = 0.393701m;
        private const decimal lbtost = 0.0714286m;

        public string NextStepsData { get { return GetValue(() => NextStepsData); } set { SetValue(() => NextStepsData, value); } }

        public object answer
        {
            get { return GetValue(() => answer); }
            set
            {
                bool raiseEvt = false;
                if (value != answer)
                    raiseEvt = true;
                SetValue(() => answer, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        public string date { get { return GetValue(() => date); } set { SetValue(() => date, value); } }
        public string key_string
        {
            get { return GetValue(() => key_string); }
            set
            {
                bool raiseEvt = false;
                if (value != key_string)
                    raiseEvt = true;
                SetValue(() => key_string, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        /// <summary>
        /// Property created for the purpose of Binding in HealthPlanView
        /// </summary>
        public string DisplayText
        {
            get
            {
                if (string.IsNullOrEmpty(answer_text))
                {
                    if (key_string == "smoking_healthplan")
                    {
                        return answer.ToString();
                    }
                    if (key_string == "alcohol_regularity")
                    { }
                    if (key_string == "weight")
                    {                        
                       return getDisplayStringForWeight();
                    }
                    if (key_string == "height")
                    {
                       return getDisplayStringForHeight();
                    }
                    if (key_string == "waist_girth")
                    {
                        return GetDisplayStringForWaistGirth();
                    }
                    if (key_string == "weight_date_objective")
                    {
                        return answer.ToString();
                    }
                    if (key_string == "mod_know")
                    { }
                    if (key_string == "mod")
                    { }
                    if (key_string == "vig_know")
                    { }
                    if (key_string == "vig")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                    if (key_string == "birthday")
                    { }
                }
                return answer_text;

            }
        }
        private String getDisplayStringForWeight()
        {
            String text = "      " + response + " " + answer.ToString();
            String unit = answer.ToString();
            if (unit == "st")
            {
                text = "      " + response1 + " " + unit + " " + response2 + " " + "lb";
            }
            else {
                text = "      " + response1 + " " + unit;
            }
            return text;
        }
        private String getDisplayStringForHeight()
        {
            String text = "      " + response + " " + answer.ToString();
            String unit = answer.ToString();
            switch (unit)
            {
                case "m":
                    text = "      " + response1 + " " + unit + " " + response2 + " " + "cm";
                    break;
                case "cm":
                    text = "      " + response1 + " " + unit;
                    break;
                default:
                    text = "      " + response1 + " " + unit + " " + response2 + " " + "inches";
                    break;
            }
            return text;
        }
        private String GetDisplayStringForWaistGirth()
        {
            return ("      " + response1 + " " + answer.ToString());
        }

        public int element_type
        {
            get { return GetValue(() => element_type); }
            set
            {
                bool raiseEvt = false;
                if (value != element_type)
                    raiseEvt = true;
                SetValue(() => element_type, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        public string question { get { return GetValue(() => question); } set { SetValue(() => question, value); } }
        public bool decimals { get { return GetValue(() => decimals); } set { SetValue(() => decimals, value); } }
        public decimal decimal_places { get { return GetValue(() => decimal_places); } set { SetValue(() => decimal_places, value); } }
        public object response2
        {
            get { return GetValue(() => response2); }
            set
            {
                bool raiseEvt = false;
                if (value != response2)
                    raiseEvt = true;
                SetValue(() => response2, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        public string answer_text
        {
            get { return GetValue(() => answer_text); }
            set
            {
                bool raiseEvt = false;
                if (value != answer_text)
                    raiseEvt = true;
                SetValue(() => answer_text, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        public string question_title { get { return GetValue(() => question_title); } set { SetValue(() => question_title, value); } }
        /*Submit Json Included*/
        public bool answer_overrider { get { return GetValue(() => answer_overrider); } set { SetValue(() => answer_overrider, value); } }
        public bool alreadyAnswered { get { return GetValue(() => alreadyAnswered); } set { SetValue(() => alreadyAnswered, value); } }
        public bool selected { get { return GetValue(() => selected); } set { SetValue(() => selected, value); } }

        public object response1
        {
            get { return GetValue(() => response1); }
            set
            {
                bool raiseEvt = false;
                if (value != response1)
                    raiseEvt = true;
                SetValue(() => response1, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }
        public object response
        {
            get { return GetValue(() => response); }
            set
            {
                bool raiseEvt = false;
                if (value != response)
                    raiseEvt = true;
                SetValue(() => response, value);
                if (raiseEvt)
                {
                    NotifyPropertyChanged("DisplayText");
                }
            }
        }

        /*helper property */

        public void ClearResponses()
        {
            response = response1 = response2 = null;
        }
        public string AnswerIsNullOrEmpty(object value)
        {
            if (value == null) { return "0"; }
            else if (Convert.ToString(value) == "") { return "0"; }
            else if (Convert.ToString(value) == "none") { return "0"; }
            else if (Convert.ToString(value) == ".") { return "0"; }
            else if (Convert.ToString(value) == "0.0") { return "0"; }
            else return Convert.ToString(value);
        }

        #region Length
        public string _responseCM;
        public string _responseM;
        public string _responseMCM;
        public string _responseFT;
        public string _responseINCH;

        public string responseCM
        {
            get { return _responseCM; }
            set
            {
                _responseCM = value == "" ? "0" : value;
                _responseM = Convert.ToString(Math.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) / 100));
                _responseMCM = Convert.ToString(Math.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) % 100));
                _responseFT = Convert.ToString(decimal.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt));
                _responseINCH = Convert.ToString(decimal.Round(((Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt) % 1) * 12));

                _responseM = _responseM == "0" ? "" : _responseM;
                _responseFT = _responseFT == "0" ? "" : _responseFT;
                _responseMCM = _responseMCM == "0" ? "" : _responseMCM;
                _responseINCH = _responseINCH == "0" ? "" : _responseINCH;
                _responseCM = _responseCM == "0" ? "" : _responseCM;

                NotifyPropertyChanged("responseCM");
                NotifyPropertyChanged("responseM");
                NotifyPropertyChanged("responseFT");
                NotifyPropertyChanged("responseMCM");
                NotifyPropertyChanged("responseINCH");
            }
        }
        public string responseM
        {
            get { return _responseM; }
            set
            {
                _responseM = value;
                _responseMCM = _responseMCM == "" ? "0" : _responseMCM;
                _responseCM = Convert.ToString(Math.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(responseM)) * 100) + Decimal.Parse(AnswerIsNullOrEmpty(_responseMCM)));
                _responseFT = Convert.ToString(Math.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt));
                _responseINCH = Convert.ToString(Math.Truncate(((Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt) % 1) * 12));
                _responseCM = _responseCM == "0" ? "" : _responseCM;

                _responseFT = _responseFT == "0" ? "" : _responseFT;
                _responseMCM = _responseMCM == "0" ? "" : _responseMCM;
                _responseINCH = _responseINCH == "0" ? "" : _responseINCH;
                NotifyPropertyChanged("responseCM");
                NotifyPropertyChanged("responseM");
                NotifyPropertyChanged("responseFT");
                NotifyPropertyChanged("responseMCM");
                NotifyPropertyChanged("responseINCH");

            }
        }
        public string responseMCM
        {
            get { return _responseMCM; }
            set
            {
                _responseMCM = value == "" ? "0" : value;
                _responseCM = Convert.ToString(Math.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseM)) * 100) + Convert.ToDecimal(AnswerIsNullOrEmpty(_responseMCM)));
                _responseM = Convert.ToString(Math.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) / 100));
                _responseFT = Convert.ToString(Math.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt));
                _responseINCH = Convert.ToString(Math.Truncate(((Convert.ToDecimal(AnswerIsNullOrEmpty(_responseCM)) * cmToFt) % 1) * 12));
                _responseCM = _responseCM == "0" ? "" : _responseCM;
                _responseM = _responseM == "0" ? "" : _responseM;
                _responseFT = _responseFT == "0" ? "" : _responseFT;

                _responseINCH = _responseINCH == "0" ? "" : _responseINCH;
                NotifyPropertyChanged("responseCM");
                NotifyPropertyChanged("responseM");
                NotifyPropertyChanged("responseFT");
                NotifyPropertyChanged("responseMCM");
                NotifyPropertyChanged("responseINCH");
            }
        }
        public string responseFT
        {
            get { return _responseFT; }
            set
            {
                _responseFT = value;
                var a = Convert.ToDecimal(_responseFT) + Convert.ToDecimal(AnswerIsNullOrEmpty(_responseINCH)) * inchesToFt;
                _responseCM = Convert.ToString(Math.Round(Convert.ToDecimal(a) * ftToCm));
                _responseM = Convert.ToString(Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(_responseCM)) / 100));
                _responseMCM = Convert.ToString(Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(_responseCM)) % 100));
                //_responseINCH = Convert.ToString(Math.Truncate(((Decimal.Parse(_responseCM == "" ? "0" : _responseCM) * cmToFt) % 1) * 12));
                _responseCM = _responseCM == "0" ? "" : _responseCM;
                _responseM = _responseM == "0" ? "" : _responseM;

                _responseMCM = _responseMCM == "0" ? "" : _responseMCM;
                _responseINCH = _responseINCH == "0" ? "" : _responseINCH;
                NotifyPropertyChanged("responseCM");
                NotifyPropertyChanged("responseM");
                NotifyPropertyChanged("responseFT");
                NotifyPropertyChanged("responseMCM");
                NotifyPropertyChanged("responseINCH");

            }
        }
        public string responseINCH
        {
            get { return _responseINCH; }
            set
            {

                //in *0.083333
                _responseINCH = value;
                var TotalFeet = Convert.ToString(
                   Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(_responseFT)) + (Decimal.Parse(AnswerIsNullOrEmpty(_responseINCH)) * inchesToFt), 2));
                _responseCM = Convert.ToString(Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(TotalFeet)) * ftToCm));
                _responseM = Convert.ToString(Math.Truncate(Decimal.Parse(AnswerIsNullOrEmpty(_responseCM)) / 100));
                _responseMCM = Convert.ToString(Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(_responseCM)) % 100));
                _responseFT = Convert.ToString(Math.Round(Decimal.Parse(AnswerIsNullOrEmpty(_responseFT))));
                _responseCM = _responseCM == "0" ? "" : _responseCM;
                _responseM = _responseM == "0" ? "" : _responseM;
                _responseFT = _responseFT == "0" ? "" : _responseFT;
                _responseMCM = _responseMCM == "0" ? "" : _responseMCM;
                _responseINCH = _responseINCH == "0" ? "" : _responseINCH;

                NotifyPropertyChanged("responseCM");
                NotifyPropertyChanged("responseM");
                NotifyPropertyChanged("responseFT");
                NotifyPropertyChanged("responseMCM");
                NotifyPropertyChanged("responseINCH");

            }
        }
        #endregion

        #region Weight

        public string _responseKG;
        public string _responseST;
        public string _responseSTLB;
        public string _responseLB;
        public string responseKG
        {
            get { return _responseKG; }
            set
            {
                _responseKG = value;
                _responseST = Convert.ToString(decimal.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(responseKG)) / stlbToKg));
                _responseSTLB = Convert.ToString(Math.Round((Convert.ToDecimal(AnswerIsNullOrEmpty(responseKG)) / stlbToKg - Math.Floor(Convert.ToDecimal(AnswerIsNullOrEmpty(responseKG)) / stlbToKg)) * 14));
                _responseLB = Convert.ToString(decimal.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(responseKG)) / lbToKg, 1));


                _responseST = _responseST == "0" ? "" : _responseST;
                _responseSTLB = _responseSTLB == "0" ? "" : _responseSTLB;
                _responseLB = _responseLB == "0" ? "" : _responseLB;

                NotifyPropertyChanged("responseKG");
                NotifyPropertyChanged("responseST");
                NotifyPropertyChanged("responseSTLB");
                NotifyPropertyChanged("responseLB");
            }
        }
        public string responseST
        {
            get { return _responseST; }
            set
            {
                _responseST = value;
                _responseKG = Convert.ToString(decimal.Round((
                                    Convert.ToDecimal(AnswerIsNullOrEmpty(responseST)) + (Convert.ToDecimal(AnswerIsNullOrEmpty(_responseSTLB)) * lbtost))
                    * stlbToKg, 1));
                _responseLB = Convert.ToString(decimal.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) / lbToKg, 2));
                _responseKG = _responseKG == "0" ? "" : responseKG;

                _responseSTLB = _responseSTLB == "0" ? "" : _responseSTLB;
                _responseLB = _responseLB == "0" ? "" : _responseLB;
                NotifyPropertyChanged("responseKG");
                NotifyPropertyChanged("responseST");
                NotifyPropertyChanged("responseSTLB");
                NotifyPropertyChanged("responseLB");
            }
        }
        public string responseSTLB
        {
            get { return _responseSTLB; }
            set
            {
                _responseSTLB = value;
                _responseKG = Convert.ToString(decimal.Round((
                                   Convert.ToDecimal(AnswerIsNullOrEmpty(responseST)) + (Convert.ToDecimal(AnswerIsNullOrEmpty(_responseSTLB)) * lbtost))
                   * stlbToKg, 1));
                _responseLB = Convert.ToString(decimal.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) / lbToKg, 2));
                _responseKG = _responseKG == "0" ? "" : responseKG;
                _responseST = _responseST == "0" ? "" : _responseST;

                _responseLB = _responseLB == "0" ? "" : _responseLB;
                NotifyPropertyChanged("responseKG");
                NotifyPropertyChanged("responseST");
                NotifyPropertyChanged("responseSTLB");
                NotifyPropertyChanged("responseLB");
            }
        }
        public string responseLB
        {
            get { return _responseLB; }
            set
            {
                _responseLB = value;
                _responseKG = Convert.ToString(decimal.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseLB)) * lbToKg, 1));
                _responseST = Convert.ToString(decimal.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) / stlbToKg));
                _responseSTLB = Convert.ToString(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) % stlbToKg);
                _responseSTLB = Convert.ToString(Math.Round((Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) / stlbToKg - Math.Floor(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseKG)) / stlbToKg)) * 14));
                _responseKG = _responseKG == "0" ? "" : responseKG;
                _responseST = _responseST == "0" ? "" : _responseST;
                _responseSTLB = _responseSTLB == "0" ? "" : _responseSTLB;

                NotifyPropertyChanged("responseKG");
                NotifyPropertyChanged("responseST");
                NotifyPropertyChanged("responseSTLB");
                NotifyPropertyChanged("responseLB");
            }
        }
        #endregion


        #region Girth Control
        public string _responseWaistGirthCM;
        public string _responseWaistGirthINCH;
        public string responseWaistGirthCM
        {
            get { return _responseWaistGirthCM; }
            set
            {
                _responseWaistGirthCM = value;
                _responseWaistGirthINCH = Convert.ToString(decimal.Round(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseWaistGirthCM)) * CmToInch));
                _responseWaistGirthINCH = AnswerIsNullOrEmpty(_responseWaistGirthINCH);
                NotifyPropertyChanged("responseWaistGirthCM");
                NotifyPropertyChanged("responseWaistGirthINCH");

            }
        }
        public string responseWaistGirthINCH
        {
            get { return _responseWaistGirthINCH; }
            set
            {
                _responseWaistGirthINCH = value;
                _responseWaistGirthCM = Convert.ToString(decimal.Truncate(Convert.ToDecimal(AnswerIsNullOrEmpty(_responseWaistGirthINCH)) / CmToInch));
                _responseWaistGirthCM = AnswerIsNullOrEmpty(_responseWaistGirthCM);
                NotifyPropertyChanged("responseWaistGirthCM");
                NotifyPropertyChanged("responseWaistGirthINCH");

            }
        }
        #endregion

        #region BloodGlucose
        public string _responsemmol_l;

        public string responsemmol_l
        {
            get { return _responsemmol_l; }
            set
            {
                _responsemmol_l = value;
                _responsemg_dl = Convert.ToString(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_l)) * 18M);
                _responsemg_g_l = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_l)) * (18M / 100M), 1));
                NotifyPropertyChanged("responsemmol_l");
                NotifyPropertyChanged("responsemg_dl");
                NotifyPropertyChanged("responsemg_g_l");
            }
        }

        private string _responsemg_dl;

        public string responsemg_dl
        {
            get { return _responsemg_dl; }
            set
            {
                _responsemg_dl = value;
                _responsemmol_l = Convert.ToString(decimal.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dl)) / 18M));
                _responsemg_g_l = Convert.ToString(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dl)) / 100);
                NotifyPropertyChanged("responsemmol_l");
                NotifyPropertyChanged("responsemg_dl");
                NotifyPropertyChanged("responsemg_g_l");
            }
        }
        private string _responsemg_g_l;

        public string responsemg_g_l
        {
            get { return _responsemg_g_l; }
            set
            {
                _responsemg_g_l = value;
                _responsemmol_l = Convert.ToString(decimal.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_l)) * (100M / 18M)));
                _responsemg_dl = Convert.ToString(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_l)) * 100);
                NotifyPropertyChanged("responsemmol_l");
                NotifyPropertyChanged("responsemg_dl");
                NotifyPropertyChanged("responsemg_g_l");
            }
        }

        #endregion

        #region BPReading
        private string _responseBPSystolicMMHG;

        public string responseBPSystolicMMHG
        {
            get { return _responseBPSystolicMMHG; }
            set
            {
                _responseBPSystolicMMHG = value == null ? "" : value;
                _responseBPSystolicMMHG10 = Convert.ToString(Decimal.Round(decimal.Parse(AnswerIsNullOrEmpty(_responseBPSystolicMMHG)) / 10));
                _responseBPSystolicMMHG10 = AnswerIsNullOrEmpty(_responseBPSystolicMMHG10);
                // _responseBPSystolicMMHG = AnswerIsNullOrEmpty(_responseBPSystolicMMHG) == "0" ? "" : _responseBPSystolicMMHG;
                _responseBPSystolicMMHG10 = AnswerIsNullOrEmpty(_responseBPSystolicMMHG10) == "0" ? "" : _responseBPSystolicMMHG10;
                NotifyPropertyChanged("responseBPSystolicMMHG");
                NotifyPropertyChanged("responseBPSystolicMMHG10");

            }
        }
        private string _responseBPDiastolicMMHG;

        public string responseBPDiastolicMMHG
        {
            get { return _responseBPDiastolicMMHG; }
            set
            {
                _responseBPDiastolicMMHG = value == null ? "" : value;
                _responseBPDiastolicMMHG10 = Convert.ToString(Decimal.Round(decimal.Parse(AnswerIsNullOrEmpty(_responseBPDiastolicMMHG)) / 10));
                _responseBPDiastolicMMHG10 = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG10);
                //_responseBPDiastolicMMHG = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG) == "0" ? "" : _responseBPDiastolicMMHG;
                _responseBPDiastolicMMHG10 = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG10) == "0" ? "" : _responseBPDiastolicMMHG10;
                NotifyPropertyChanged("responseBPDiastolicMMHG");
                NotifyPropertyChanged("responseBPDiastolicMMHG10");
            }
        }

        private string _responseBPSystolicMMHG10;

        public string responseBPSystolicMMHG10
        {
            get { return _responseBPSystolicMMHG10; }
            set
            {
                _responseBPSystolicMMHG10 = value;
                _responseBPSystolicMMHG = Convert.ToString(Decimal.Truncate(decimal.Parse(AnswerIsNullOrEmpty(_responseBPSystolicMMHG10)) * 10));
                _responseBPSystolicMMHG = AnswerIsNullOrEmpty(_responseBPSystolicMMHG);
                _responseBPSystolicMMHG = AnswerIsNullOrEmpty(_responseBPSystolicMMHG) == "0" ? "" : _responseBPSystolicMMHG;
                //_responseBPSystolicMMHG10 = AnswerIsNullOrEmpty(_responseBPSystolicMMHG10) == "0" ? "" : _responseBPSystolicMMHG10;
                NotifyPropertyChanged("responseBPSystolicMMHG");
                NotifyPropertyChanged("responseBPSystolicMMHG10");
            }
        }
        private string _responseBPDiastolicMMHG10;

        public string responseBPDiastolicMMHG10
        {
            get { return _responseBPDiastolicMMHG10; }
            set
            {
                _responseBPDiastolicMMHG10 = value;
                _responseBPDiastolicMMHG = Convert.ToString(Decimal.Truncate(decimal.Parse(AnswerIsNullOrEmpty(_responseBPDiastolicMMHG10)) * 10));
                _responseBPDiastolicMMHG = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG);
                _responseBPDiastolicMMHG = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG) == "0" ? "" : _responseBPDiastolicMMHG;
                //_responseBPSystolicMMHG10 = AnswerIsNullOrEmpty(_responseBPDiastolicMMHG10) == "0" ? "" : _responseBPDiastolicMMHG10;
                NotifyPropertyChanged("responseBPDiastolicMMHG");
                NotifyPropertyChanged("responseBPDiastolicMMHG10");

            }
        }
        #endregion

        #region Cholesterol level

        private string _responsemmol_lTotalCholesterol;

        public string responsemmol_lTotalCholesterol
        {
            get { return _responsemmol_lTotalCholesterol; }
            set
            {

                _responsemmol_lTotalCholesterol = value;
                _responsemg_dlTotalCholesterol = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol)) * 38.7M));
                _responsemg_g_lTotalCholesterol = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol)) / 2.584M, 1));

                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);


                NotifyPropertyChanged("responsemmol_lTotalCholesterol");
                NotifyPropertyChanged("responsemg_dlTotalCholesterol");
                NotifyPropertyChanged("responsemg_g_lTotalCholesterol");
            }
        }
        private string _responsemmol_lHDL;

        public string responsemmol_lHDL
        {
            get { return _responsemmol_lHDL; }
            set
            {
                _responsemmol_lHDL = value;
                _responsemg_dlHDL = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_lHDL)) * 38.7M));
                _responsemg_g_lHDL = Convert.ToString((Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemmol_lHDL)) / 2.584M, 1)));

                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);
                NotifyPropertyChanged("responsemmol_lHDL");
                NotifyPropertyChanged("responsemg_dlHDL");
                NotifyPropertyChanged("responsemg_g_lHDL");
            }
        }
        private string _responsemg_dlTotalCholesterol;

        public string responsemg_dlTotalCholesterol
        {
            get { return _responsemg_dlTotalCholesterol; }
            set
            {
                _responsemg_dlTotalCholesterol = value;
                _responsemmol_lTotalCholesterol = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol)) / 38.7M, 1));
                _responsemg_g_lTotalCholesterol = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol)) / 100, 1));

                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);
                NotifyPropertyChanged("responsemmol_lTotalCholesterol");
                NotifyPropertyChanged("responsemg_dlTotalCholesterol");
                NotifyPropertyChanged("responsemg_g_lTotalCholesterol");

            }
        }
        private string _responsemg_dlHDL;

        public string responsemg_dlHDL
        {
            get { return _responsemg_dlHDL; }
            set
            {
                _responsemg_dlHDL = value;
                _responsemmol_lHDL = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dlHDL)) / 38.7M));
                _responsemg_g_lHDL = Convert.ToString(Math.Round((decimal.Parse(AnswerIsNullOrEmpty(_responsemg_dlHDL)) / 100), 1));

                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);
                NotifyPropertyChanged("responsemmol_lHDL");
                NotifyPropertyChanged("responsemg_dlHDL");
                NotifyPropertyChanged("responsemg_g_lHDL");
            }
        }

        private string _responsemg_g_lTotalCholesterol;

        public string responsemg_g_lTotalCholesterol
        {
            get { return _responsemg_g_lTotalCholesterol; }
            set
            {
                _responsemg_g_lTotalCholesterol = value;
                _responsemmol_lTotalCholesterol = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol)) * 2.584M, 1));
                _responsemg_dlTotalCholesterol = Convert.ToString(Math.Round(Convert.ToDecimal(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol)) * 100)));


                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);
                NotifyPropertyChanged("responsemmol_lTotalCholesterol");
                NotifyPropertyChanged("responsemg_dlTotalCholesterol");
                NotifyPropertyChanged("responsemg_g_lTotalCholesterol");
            }
        }
        private string _responsemg_g_lHDL;

        public string responsemg_g_lHDL
        {
            get { return _responsemg_g_lHDL; }
            set
            {
                _responsemg_g_lHDL = value;
                _responsemmol_lHDL = Convert.ToString(Math.Round(decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_lHDL)) * 2.584M));
                _responsemg_dlHDL = Convert.ToString(Math.Round((decimal.Parse(AnswerIsNullOrEmpty(_responsemg_g_lHDL)) * 100)));

                _responsemg_dlHDL = AnswerIsNullOrEmpty(_responsemg_dlHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlHDL);
                _responsemg_g_lHDL = AnswerIsNullOrEmpty(_responsemg_g_lHDL) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lHDL);
                _responsemg_dlTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_dlTotalCholesterol);
                _responsemg_g_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemg_g_lTotalCholesterol);
                _responsemmol_lTotalCholesterol = AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol) == "0" ? "" : AnswerIsNullOrEmpty(_responsemmol_lTotalCholesterol);
                NotifyPropertyChanged("responsemmol_lHDL");
                NotifyPropertyChanged("responsemg_dlHDL");
                NotifyPropertyChanged("responsemg_g_lHDL");
            }
        }

        #endregion
    }

    public class Algorithm
    {
        public string _id { get; set; }
        public string questionnaire { get; set; }
        public string key_string { get; set; }
        public string units { get; set; }
        public double value { get; set; }
        public object response { get; set; }
        public string risk_factor { get; set; }
    }

    public class AnsweredQuestionnaireIdsArr
    {
        public bool success { get; set; }
        public string questionnaire { get; set; }
    }
    public class User : NotifyBase
    {
        public object locale { get; set; }
        public int __v { get; set; }
        public int status { get; set; }
        public string _id { get; set; }
        public string email { get; set; }
        public string modified { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public bool can_use_for_testing { get; set; }
        public int timezone_offset { get; set; }
        public bool deleted { get; set; }
        public int age { get; set; }
        public string dob { get; set; }
        public List<SocialLogin> sociallogins { get; set; }
        public string type { get; set; }
        public string coach { get; set; }
        public string ethnicity_real { get; set; }
        public int ethnicity { get; set; }
        public int gender { get; set; }
        public double score { get; set; }
        public List<string> answered_questionnaire_ids { get; set; }
        public string last_hra { get; set; }
        public List<ScoreHistory> score_history { get; set; }
        public List<Answer> answers { get { return GetValue(() => answers); } set { SetValue(() => answers, value); } }
        public List<Algorithm> algorithms { get { return GetValue(() => algorithms); } set { SetValue(() => algorithms, value); } }
        public string country { get; set; }
        public List<object> product_categories { get { return GetValue(() => product_categories); } set { SetValue(() => product_categories, value); } }
        public string language { get; set; }
        public List<object> deactivation_reason { get { return GetValue(() => deactivation_reason); } set { SetValue(() => deactivation_reason, value); } }
        public int hierarchy { get; set; }
        public bool validated_email { get; set; }
        public long created { get; set; }
        public List<AnsweredQuestionnaireIdsArr> answered_questionnaire_ids_arr { get { return GetValue(() => answered_questionnaire_ids_arr); } set { SetValue(() => answered_questionnaire_ids_arr, value); } }
        public bool hasHealthObjectives
        {
            get { return GetValue(() => this.hasHealthObjectives); }
            set { SetValue(() => hasHealthObjectives, value); }
        }
        public string socialmedia_id { get; set; }

        #region Custome object
        public string message { get; set; }

        [NonSerialized]
        public SecureString Securepwd;
        public string password
        {
            get
            {
                return Securepwd != null && Securepwd.Length > 0 ? Securepwd.Value() : string.Empty;
            }
            private set { }
        }

        public string confirm { get; set; }
        public AuthToken AuthToken { get; set; }
        public string responsecode { get; set; }
        public bool LastHra { get; set; }
        public string salt { get; set; }
        public string hashed_password { get; set; }
        public string device_type { get; set; }
        public string device_id { get; set; }
        public string provider { get; set; }
        public bool notified { get; set; }
        public bool discloseData { get; set; }
        public object DOB { get; set; }
        public List<object> humanApi { get; set; }
        #endregion

    }
    public class SocialLogin
    {
        public string socialmedia_id { get; set; }
        public string socialmedia_type { get; set; }
        public string _id { get; set; }
    }
}
