using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
 
    public class Headings
    {
        public string q_score { get; set; }
        public string bmi { get; set; }
        public string waist_girth { get; set; }
        public string physical_activity { get; set; }
        public string smoking { get; set; }
        public string high_fibre { get; set; }
        public string refined_carbs { get; set; }
        public string healthy_fats { get; set; }
    }

    public class Gender
    {
        public bool male { get; set; }
        public int q_score { get; set; }
        public string q_score_rag { get; set; }
        public string bmi { get; set; }
        public string bmi_rag { get; set; }
        public string waist_girth { get; set; }
        public string waist_girth_rag { get; set; }
        public string physical_activity { get; set; }
        public string physical_activity_rag { get; set; }
        public string smoking { get; set; }
        public string high_fibre { get; set; }
        public string high_fibre_rag { get; set; }
        public string refined_carbs { get; set; }
        public string refined_carbs_rag { get; set; }
        public string healthy_fats { get; set; }
        public string healthy_fats_rag { get; set; }
    }

    public class AgeGender
    {
        public bool male { get; set; }
        public int age { get; set; }
        public int q_score { get; set; }
        public string q_score_rag { get; set; }
        public string bmi { get; set; }
        public string bmi_rag { get; set; }
        public string waist_girth { get; set; }
        public string waist_girth_rag { get; set; }
        public string physical_activity { get; set; }
        public string physical_activity_rag { get; set; }
        public string smoking { get; set; }
        public string high_fibre { get; set; }
        public string high_fibre_rag { get; set; }
        public string refined_carbs { get; set; }
        public string refined_carbs_rag { get; set; }
        public string healthy_fats { get; set; }
        public string healthy_fats_rag { get; set; }
    }

    public class Users:NotifyBase
    {
        public string suffix { get; set; }
        public string my_score
        {
            get { return GetValue(() => my_score); }
            set { SetValue(() => my_score, value); }
        }
        public string selected_back_class { get; set; }
        public string selected_color { get; set; }
        public string key_string { get; set; }

        #region custom keys
        public string key_text { get; set; }

        public string tab_color
        {
            get { return GetValue(() => tab_color); }
            set { SetValue(() => tab_color, value); }
        }
        #endregion

        public UserData userData
        {
            get { return GetValue(() => userData); }
            set { SetValue(() => userData, value); }
        }

    }

    public class Data:NotifyBase
    {
        public Headings headings { get; set; }
        public Gender gender { get; set; }
        public AgeGender age_gender { get; set; }

        public List<Users> user
        {
            get { return GetValue(() => user); }
            set { SetValue(() => user, value); }
        }
    }

    public class Insight
    {
        public int status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

        #region Input Attributes ... will change once more information received ...

        public string questionaireId { get; set; }

        public string ethnicity { get; set; }

        public int age { get; set; }

        public bool male { get; set; }

        public string language { get; set; }

        public string userId { get; set; }

        #endregion
    }

    public class UserData: NotifyBase
    {
        public string Title
        {
            get { return GetValue(() => Title); }
            set { SetValue(() => Title, value); }
        }       
        public string TitleColor
        {
            get { return GetValue(() => TitleColor); }
            set { SetValue(() => TitleColor, value); }
        }
        public string AgeGenderTitle
        {
            get { return GetValue(() => AgeGenderTitle); }
            set { SetValue(() => AgeGenderTitle, value); }
        }       
        public string AgeGenderScore
        {
            get { return GetValue(() => AgeGenderScore); }
            set { SetValue(() => AgeGenderScore, value); }
        }
        public string AgeGenderColor
        {
            get { return GetValue(() => AgeGenderColor); }
            set { SetValue(() => AgeGenderColor, value); }
        }
        public string GenderTitle
        {
            get { return GetValue(() => GenderTitle); }
            set { SetValue(() => GenderTitle, value); }
        }       
        public string GenderScore
        {
            get { return GetValue(() => GenderScore); }
            set { SetValue(() => GenderScore, value); }
        }
        public string GenderColor
        {
            get { return GetValue(() => GenderColor); }
            set { SetValue(() => GenderColor, value); }
        }
        
    }

}
