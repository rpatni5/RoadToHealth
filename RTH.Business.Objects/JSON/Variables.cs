﻿using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class Variable : NotifyBase
    {
        public String medium_strap { get { return GetValue(() => medium_strap); } set { SetValue(() => medium_strap, value); } }
        public String blood_glucose { get { return GetValue(() => blood_glucose); } set { SetValue(() => blood_glucose, value); } }
        public String physical_activity { get { return GetValue(() => physical_activity); } set { SetValue(() => physical_activity, value); } }
        public String high_risk { get { return GetValue(() => high_risk); } set { SetValue(() => high_risk, value); } }
        public String low_strap { get { return GetValue(() => low_strap); } set { SetValue(() => low_strap, value); } }
        public String bmi { get { return GetValue(() => bmi); } set { SetValue(() => bmi, value); } }
        public String refined_carbs { get { return GetValue(() => refined_carbs); } set { SetValue(() => refined_carbs, value); } }
        public String centimetres { get { return GetValue(() => centimetres); } set { SetValue(() => centimetres, value); } }
        public String medium_risk { get { return GetValue(() => medium_risk); } set { SetValue(() => medium_risk, value); } }
        public String risk_head_you { get { return GetValue(() => risk_head_you); } set { SetValue(() => risk_head_you, value); } }
        public String healthy_fats { get { return GetValue(() => healthy_fats); } set { SetValue(() => healthy_fats, value); } }
        public String smoking { get { return GetValue(() => smoking); } set { SetValue(() => smoking, value); } }
        public String low_risk { get { return GetValue(() => low_risk); } set { SetValue(() => low_risk, value); } }
        public String risk_head_yours { get { return GetValue(() => risk_head_yours); } set { SetValue(() => risk_head_yours, value); } }
        public String high_fibre { get { return GetValue(() => high_fibre); } set { SetValue(() => high_fibre, value); } }
        public String cigs_per_day { get { return GetValue(() => cigs_per_day); } set { SetValue(() => cigs_per_day, value); } }
        public String high_strap { get { return GetValue(() => high_strap); } set { SetValue(() => high_strap, value); } }
        public String risk_head_neutral { get { return GetValue(() => risk_head_neutral); } set { SetValue(() => risk_head_neutral, value); } }
        public String high_risk_ethnicity { get { return GetValue(() => high_risk_ethnicity); } set { SetValue(() => high_risk_ethnicity, value); } }
        public String waist_girth { get { return GetValue(() => waist_girth); } set { SetValue(() => waist_girth, value); } }
        public String inches { get { return GetValue(() => inches); } set { SetValue(() => inches, value); } }
        public String cm { get { return GetValue(() => cm); } set { SetValue(() => cm, value); } }
        public String met_mins { get { return GetValue(() => met_mins); } set { SetValue(() => met_mins, value); } }
        public String prev_button { get { return GetValue(() => prev_button); } set { SetValue(() => prev_button, value); } }
        public String next_button { get { return GetValue(() => next_button); } set { SetValue(() => next_button, value); } }
        public String risk_assessment { get { return GetValue(() => risk_assessment); } set { SetValue(() => risk_assessment, value); } }
        public String dashboard { get { return GetValue(() => dashboard); } set { SetValue(() => dashboard, value); } }
        public String insights { get { return GetValue(() => insights); } set { SetValue(() => insights, value); } }
        public String feedback { get { return GetValue(() => feedback); } set { SetValue(() => feedback, value); } }
        public String healthy_zone { get { return GetValue(() => healthy_zone); } set { SetValue(() => healthy_zone, value); } }
        public String transition_zone { get { return GetValue(() => transition_zone); } set { SetValue(() => transition_zone, value); } }
        public String high_risk_zone { get { return GetValue(() => high_risk_zone); } set { SetValue(() => high_risk_zone, value); } }
        public String number_0 { get { return GetValue(() => number_0); } set { SetValue(() => number_0, value); } }
        public String view_insights { get { return GetValue(() => view_insights); } set { SetValue(() => view_insights, value); } }
        public String see_insights { get { return GetValue(() => see_insights); } set { SetValue(() => see_insights, value); } }
        public String current_q_score { get { return GetValue(() => current_q_score); } set { SetValue(() => current_q_score, value); } }
        public String now { get { return GetValue(() => now); } set { SetValue(() => now, value); } }
        public String learn_more { get { return GetValue(() => learn_more); } set { SetValue(() => learn_more, value); } }
        public String cto_compare { get { return GetValue(() => cto_compare); } set { SetValue(() => cto_compare, value); } }
        public String optimal { get { return GetValue(() => optimal); } set { SetValue(() => optimal, value); } }
        public String update_results { get { return GetValue(() => update_results); } set { SetValue(() => update_results, value); } }
        public String my_q_score { get { return GetValue(() => my_q_score); } set { SetValue(() => my_q_score, value); } }
        public String terms { get { return GetValue(() => terms); } set { SetValue(() => terms, value); } }
        public String policies { get { return GetValue(() => policies); } set { SetValue(() => policies, value); } }
        public String settings { get { return GetValue(() => settings); } set { SetValue(() => settings, value); } }
        public String login { get { return GetValue(() => login); } set { SetValue(() => login, value); } }
        public String logout { get { return GetValue(() => logout); } set { SetValue(() => logout, value); } }
        public String general { get { return GetValue(() => general); } set { SetValue(() => general, value); } }
        public String name { get { return GetValue(() => name); } set { SetValue(() => name, value); } }
        public String change_details { get { return GetValue(() => change_details); } set { SetValue(() => change_details, value); } }
        public String language { get { return GetValue(() => language); } set { SetValue(() => language, value); } }
        public String update_details { get { return GetValue(() => update_details); } set { SetValue(() => update_details, value); } }
        public String score { get { return GetValue(() => score); } set { SetValue(() => score, value); } }
        public String your { get { return GetValue(() => your); } set { SetValue(() => your, value); } }
        public String optimum { get { return GetValue(() => optimum); } set { SetValue(() => optimum, value); } }
        public String peer_average { get { return GetValue(() => peer_average); } set { SetValue(() => peer_average, value); } }
        public String your_dashboard { get { return GetValue(() => your_dashboard); } set { SetValue(() => your_dashboard, value); } }
        public String men { get { return GetValue(() => men); } set { SetValue(() => men, value); } }
        public String women { get { return GetValue(() => women); } set { SetValue(() => women, value); } }
        public String compare { get { return GetValue(() => compare); } set { SetValue(() => compare, value); } }
        public String year_old_men { get { return GetValue(() => year_old_men); } set { SetValue(() => year_old_men, value); } }
        public String year_old_women { get { return GetValue(() => year_old_women); } set { SetValue(() => year_old_women, value); } }
        public String men_whole { get { return GetValue(() => men_whole); } set { SetValue(() => men_whole, value); } }
        public String women_whole { get { return GetValue(() => women_whole); } set { SetValue(() => women_whole, value); } }
        public String prevalence { get { return GetValue(() => prevalence); } set { SetValue(() => prevalence, value); } }
        public String q_score { get { return GetValue(() => q_score); } set { SetValue(() => q_score, value); } }
        public String inches_word { get { return GetValue(() => inches_word); } set { SetValue(() => inches_word, value); } }
        public String smoking_status { get { return GetValue(() => smoking_status); } set { SetValue(() => smoking_status, value); } }
        public String high_fibre_intake { get { return GetValue(() => high_fibre_intake); } set { SetValue(() => high_fibre_intake, value); } }
        public String refined_carbs_intake { get { return GetValue(() => refined_carbs_intake); } set { SetValue(() => refined_carbs_intake, value); } }
        public String healthy_fat_intake { get { return GetValue(() => healthy_fat_intake); } set { SetValue(() => healthy_fat_intake, value); } }
        public String cm_word { get { return GetValue(() => cm_word); } set { SetValue(() => cm_word, value); } }
        public String invalid_login { get { return GetValue(() => invalid_login); } set { SetValue(() => invalid_login, value); } }
        public String log_in { get { return GetValue(() => log_in); } set { SetValue(() => log_in, value); } }
        public String sign_up { get { return GetValue(() => sign_up); } set { SetValue(() => sign_up, value); } }
        public String version { get { return GetValue(() => version); } set { SetValue(() => version, value); } }
        public String welcome_message { get { return GetValue(() => welcome_message); } set { SetValue(() => welcome_message, value); } }
        public String password { get { return GetValue(() => password); } set { SetValue(() => password, value); } }
        public String email { get { return GetValue(() => email); } set { SetValue(() => email, value); } }
        public String risk_factors { get { return GetValue(() => risk_factors); } set { SetValue(() => risk_factors, value); } }
        public String close_action { get { return GetValue(() => close_action); } set { SetValue(() => close_action, value); } }
        public String back_to_q { get { return GetValue(() => back_to_q); } set { SetValue(() => back_to_q, value); } }
        public String full_name { get { return GetValue(() => full_name); } set { SetValue(() => full_name, value); } }
        public String confirm_password { get { return GetValue(() => confirm_password); } set { SetValue(() => confirm_password, value); } }
        public String valid_email { get { return GetValue(() => valid_email); } set { SetValue(() => valid_email, value); } }
        public String missing_email { get { return GetValue(() => missing_email); } set { SetValue(() => missing_email, value); } }
        public String terms_long { get { return GetValue(() => terms_long); } set { SetValue(() => terms_long, value); } }
        public String policy_long { get { return GetValue(() => policy_long); } set { SetValue(() => policy_long, value); } }
        public String disclaimer { get { return GetValue(() => disclaimer); } set { SetValue(() => disclaimer, value); } }
        public String and { get { return GetValue(() => and); } set { SetValue(() => and, value); } }
        public String health_plan { get { return GetValue(() => health_plan); } set { SetValue(() => health_plan, value); } }
        public String m_cm { get { return GetValue(() => m_cm); } set { SetValue(() => m_cm, value); } }
        public String ft_inches { get { return GetValue(() => ft_inches); } set { SetValue(() => ft_inches, value); } }
        public String kg { get { return GetValue(() => kg); } set { SetValue(() => kg, value); } }
        public String st_lb { get { return GetValue(() => st_lb); } set { SetValue(() => st_lb, value); } }
        public String lb { get { return GetValue(() => lb); } set { SetValue(() => lb, value); } }
        public String mmol_l { get { return GetValue(() => mmol_l); } set { SetValue(() => mmol_l, value); } }
        public String calculate { get { return GetValue(() => calculate); } set { SetValue(() => calculate, value); } }
        public String @continue { get { return GetValue(() => @continue); } set { SetValue(() => @continue, value); } }
        public String not_connected { get { return GetValue(() => not_connected); } set { SetValue(() => not_connected, value); } }
        public String alert { get { return GetValue(() => alert); } set { SetValue(() => alert, value); } }
        public String password_mismatched { get { return GetValue(() => password_mismatched); } set { SetValue(() => password_mismatched, value); } }
        public String missing_answer { get { return GetValue(() => missing_answer); } set { SetValue(() => missing_answer, value); } }
        public String missing_option { get { return GetValue(() => missing_option); } set { SetValue(() => missing_option, value); } }
        public String invalid_date_entry { get { return GetValue(() => invalid_date_entry); } set { SetValue(() => invalid_date_entry, value); } }
        public String invalid_email_entry { get { return GetValue(() => invalid_email_entry); } set { SetValue(() => invalid_email_entry, value); } }
        public String yes { get { return GetValue(() => yes); } set { SetValue(() => yes, value); } }
        public String month_jan { get { return GetValue(() => month_jan); } set { SetValue(() => month_jan, value); } }
        public String month_feb { get { return GetValue(() => month_feb); } set { SetValue(() => month_feb, value); } }
        public String month_mar { get { return GetValue(() => month_mar); } set { SetValue(() => month_mar, value); } }
        public String month_apr { get { return GetValue(() => month_apr); } set { SetValue(() => month_apr, value); } }
        public String month_may { get { return GetValue(() => month_may); } set { SetValue(() => month_may, value); } }
        public String month_jun { get { return GetValue(() => month_jun); } set { SetValue(() => month_jun, value); } }
        public String month_jul { get { return GetValue(() => month_jul); } set { SetValue(() => month_jul, value); } }
        public String month_aug { get { return GetValue(() => month_aug); } set { SetValue(() => month_aug, value); } }
        public String month_sep { get { return GetValue(() => month_sep); } set { SetValue(() => month_sep, value); } }
        public String month_oct { get { return GetValue(() => month_oct); } set { SetValue(() => month_oct, value); } }
        public String month_nov { get { return GetValue(() => month_nov); } set { SetValue(() => month_nov, value); } }
        public String month_dec { get { return GetValue(() => month_dec); } set { SetValue(() => month_dec, value); } }
        public String date_rd { get { return GetValue(() => date_rd); } set { SetValue(() => date_rd, value); } }
        public String date_st { get { return GetValue(() => date_st); } set { SetValue(() => date_st, value); } }
        public String date_nd { get { return GetValue(() => date_nd); } set { SetValue(() => date_nd, value); } }
        public String date_th { get { return GetValue(() => date_th); } set { SetValue(() => date_th, value); } }
        public String today { get { return GetValue(() => today); } set { SetValue(() => today, value); } }
        public String male { get { return GetValue(() => male); } set { SetValue(() => male, value); } }
        public String feet { get { return GetValue(() => feet); } set { SetValue(() => feet, value); } }
        public String m { get { return GetValue(() => m); } set { SetValue(() => m, value); } }
        public String st { get { return GetValue(() => st); } set { SetValue(() => st, value); } }
        public String mg_dl { get { return GetValue(() => mg_dl); } set { SetValue(() => mg_dl, value); } }
        public String total { get { return GetValue(() => total); } set { SetValue(() => total, value); } }
        public String hdl { get { return GetValue(() => hdl); } set { SetValue(() => hdl, value); } }
        public String systolic { get { return GetValue(() => systolic); } set { SetValue(() => systolic, value); } }
        public String diastolic { get { return GetValue(() => diastolic); } set { SetValue(() => diastolic, value); } }
        public String mmhg { get { return GetValue(() => mmhg); } set { SetValue(() => mmhg, value); } }
        public String mmhg10 { get { return GetValue(() => mmhg10); } set { SetValue(() => mmhg10, value); } }
        public String decimal_place { get { return GetValue(() => decimal_place); } set { SetValue(() => decimal_place, value); } }
        public String alcohol_units { get { return GetValue(() => alcohol_units); } set { SetValue(() => alcohol_units, value); } }
        public String non_smoker { get { return GetValue(() => non_smoker); } set { SetValue(() => non_smoker, value); } }
        public String never_measured { get { return GetValue(() => never_measured); } set { SetValue(() => never_measured, value); } }
        public String occasional_drinker { get { return GetValue(() => occasional_drinker); } set { SetValue(() => occasional_drinker, value); } }
        public String non_drinker { get { return GetValue(() => non_drinker); } set { SetValue(() => non_drinker, value); } }
        public String intake_high { get { return GetValue(() => intake_high); } set { SetValue(() => intake_high, value); } }
        public String intake_low { get { return GetValue(() => intake_low); } set { SetValue(() => intake_low, value); } }
        public String intake_moderate { get { return GetValue(() => intake_moderate); } set { SetValue(() => intake_moderate, value); } }
        public String intake_zero { get { return GetValue(() => intake_zero); } set { SetValue(() => intake_zero, value); } }
        public String intake_healthy { get { return GetValue(() => intake_healthy); } set { SetValue(() => intake_healthy, value); } }
        public String mtwh { get { return GetValue(() => mtwh); } set { SetValue(() => mtwh, value); } }
        public String friends_of_q { get { return GetValue(() => friends_of_q); } set { SetValue(() => friends_of_q, value); } }
        public String devices_services { get { return GetValue(() => devices_services); } set { SetValue(() => devices_services, value); } }
        public String about { get { return GetValue(() => about); } set { SetValue(() => about, value); } }
        public String unknown { get { return GetValue(() => unknown); } set { SetValue(() => unknown, value); } }
        public String low { get { return GetValue(() => low); } set { SetValue(() => low, value); } }
        public String normal { get { return GetValue(() => normal); } set { SetValue(() => normal, value); } }
        public String high { get { return GetValue(() => high); } set { SetValue(() => high, value); } }
        public String stress_high { get { return GetValue(() => stress_high); } set { SetValue(() => stress_high, value); } }
        public String stress_moderate { get { return GetValue(() => stress_moderate); } set { SetValue(() => stress_moderate, value); } }
        public String stress_low { get { return GetValue(() => stress_low); } set { SetValue(() => stress_low, value); } }
        public String moderate { get { return GetValue(() => moderate); } set { SetValue(() => moderate, value); } }
        public String invite_a_friend { get { return GetValue(() => invite_a_friend); } set { SetValue(() => invite_a_friend, value); } }
        public String send { get { return GetValue(() => send); } set { SetValue(() => send, value); } }
        public String share_with_friends { get { return GetValue(() => share_with_friends); } set { SetValue(() => share_with_friends, value); } }
        public String share_with_fb { get { return GetValue(() => share_with_fb); } set { SetValue(() => share_with_fb, value); } }
        public String share_with_twitter { get { return GetValue(() => share_with_twitter); } set { SetValue(() => share_with_twitter, value); } }
        public String share_with_contacts { get { return GetValue(() => share_with_contacts); } set { SetValue(() => share_with_contacts, value); } }
        public String account { get { return GetValue(() => account); } set { SetValue(() => account, value); } }
        public String no_devices_are_currently_connected { get { return GetValue(() => no_devices_are_currently_connected); } set { SetValue(() => no_devices_are_currently_connected, value); } }
        public String connect_your_device { get { return GetValue(() => connect_your_device); } set { SetValue(() => connect_your_device, value); } }
        public String connect_to_s_health { get { return GetValue(() => connect_to_s_health); } set { SetValue(() => connect_to_s_health, value); } }
        public String connect_to_Social { get { return GetValue(() => connect_to_Social); } set { SetValue(() => connect_to_Social, value); } }
        public String connect_to_twitter { get { return GetValue(() => connect_to_twitter); } set { SetValue(() => connect_to_twitter, value); } }
        public String connect_to_Fb { get { return GetValue(() => connect_to_Fb); } set { SetValue(() => connect_to_Fb, value); } }
        public String feedback_message { get { return GetValue(() => feedback_message); } set { SetValue(() => feedback_message, value); } }
        public String proceed { get { return GetValue(() => proceed); } set { SetValue(() => proceed, value); } }
        public String cancel { get { return GetValue(() => cancel); } set { SetValue(() => cancel, value); } }
        public String legal { get { return GetValue(() => legal); } set { SetValue(() => legal, value); } }
        public String go { get { return GetValue(() => go); } set { SetValue(() => go, value); } }
        public String warning { get { return GetValue(() => warning); } set { SetValue(() => warning, value); } }
        public String hra_warning_message { get { return GetValue(() => hra_warning_message); } set { SetValue(() => hra_warning_message, value); } }
        public String no { get { return GetValue(() => no); } set { SetValue(() => no, value); } }
        public String please_select_an_option { get { return GetValue(() => please_select_an_option); } set { SetValue(() => please_select_an_option, value); } }
        public String please_enter_your_answer { get { return GetValue(() => please_enter_your_answer); } set { SetValue(() => please_enter_your_answer, value); } }
        public String login_with_facebook { get { return GetValue(() => login_with_facebook); } set { SetValue(() => login_with_facebook, value); } }
        public String login_with_twitter { get { return GetValue(() => login_with_twitter); } set { SetValue(() => login_with_twitter, value); } }
        public String dont_have_account { get { return GetValue(() => dont_have_account); } set { SetValue(() => dont_have_account, value); } }
        public String forgot_your_password { get { return GetValue(() => forgot_your_password); } set { SetValue(() => forgot_your_password, value); } }
        public String or { get { return GetValue(() => or); } set { SetValue(() => or, value); } }
        public String almost_there { get { return GetValue(() => almost_there); } set { SetValue(() => almost_there, value); } }
        public String signup_with_fb { get { return GetValue(() => signup_with_fb); } set { SetValue(() => signup_with_fb, value); } }
        public String signup_with_twitter { get { return GetValue(() => signup_with_twitter); } set { SetValue(() => signup_with_twitter, value); } }
        public String health_guidelines { get { return GetValue(() => health_guidelines); } set { SetValue(() => health_guidelines, value); } }
        public String overview { get { return GetValue(() => overview); } set { SetValue(() => overview, value); } }
        public String optimum_q { get { return GetValue(() => optimum_q); } set { SetValue(() => optimum_q, value); } }
        public String current_q { get { return GetValue(() => current_q); } set { SetValue(() => current_q, value); } }
        public String temp_password_request { get { return GetValue(() => temp_password_request); } set { SetValue(() => temp_password_request, value); } }
        public String send_me_temprary_password { get { return GetValue(() => send_me_temprary_password); } set { SetValue(() => send_me_temprary_password, value); } }
        public String please_enter_value { get { return GetValue(() => please_enter_value); } set { SetValue(() => please_enter_value, value); } }
        public String help { get { return GetValue(() => help); } set { SetValue(() => help, value); } }
        public String please_enter_name { get { return GetValue(() => please_enter_name); } set { SetValue(() => please_enter_name, value); } }
        public String please_enter_valid_name { get { return GetValue(() => please_enter_valid_name); } set { SetValue(() => please_enter_valid_name, value); } }
        public String name_must_be_of_two_characters { get { return GetValue(() => name_must_be_of_two_characters); } set { SetValue(() => name_must_be_of_two_characters, value); } }
        public String please_enter_password { get { return GetValue(() => please_enter_password); } set { SetValue(() => please_enter_password, value); } }
        public String please_enter_confirm_password { get { return GetValue(() => please_enter_confirm_password); } set { SetValue(() => please_enter_confirm_password, value); } }
        public String minimum_password_length_message { get { return GetValue(() => minimum_password_length_message); } set { SetValue(() => minimum_password_length_message, value); } }
        public String password_must_contain_numbers_and_special_char { get { return GetValue(() => password_must_contain_numbers_and_special_char); } set { SetValue(() => password_must_contain_numbers_and_special_char, value); } }
        public String please_select_language { get { return GetValue(() => please_select_language); } set { SetValue(() => please_select_language, value); } }
        public String please_select_country { get { return GetValue(() => please_select_country); } set { SetValue(() => please_select_country, value); } }
        public String user_not_exist { get { return GetValue(() => user_not_exist); } set { SetValue(() => user_not_exist, value); } }
        public String enter_old_password { get { return GetValue(() => enter_old_password); } set { SetValue(() => enter_old_password, value); } }
        public String enter_new_password { get { return GetValue(() => enter_new_password); } set { SetValue(() => enter_new_password, value); } }
        public String wrong_old_password { get { return GetValue(() => wrong_old_password); } set { SetValue(() => wrong_old_password, value); } }
        public String same_password_found { get { return GetValue(() => same_password_found); } set { SetValue(() => same_password_found, value); } }
        public String enter_dob { get { return GetValue(() => enter_dob); } set { SetValue(() => enter_dob, value); } }
        public String enter_confirm_new_password { get { return GetValue(() => enter_confirm_new_password); } set { SetValue(() => enter_confirm_new_password, value); } }
        public String settings_password_mismatched { get { return GetValue(() => settings_password_mismatched); } set { SetValue(() => settings_password_mismatched, value); } }
        public String validation_select_dob { get { return GetValue(() => validation_select_dob); } set { SetValue(() => validation_select_dob, value); } }
        public String total_cholestorl { get { return GetValue(() => total_cholestorl); } set { SetValue(() => total_cholestorl, value); } }
        public String g_l { get { return GetValue(() => g_l); } set { SetValue(() => g_l, value); } }
        public String forgotten_password { get { return GetValue(() => forgotten_password); } set { SetValue(() => forgotten_password, value); } }
        public String signin_help { get { return GetValue(() => signin_help); } set { SetValue(() => signin_help, value); } }
        public String request_an_access_code { get { return GetValue(() => request_an_access_code); } set { SetValue(() => request_an_access_code, value); } }
        public String already_have_an_access_code { get { return GetValue(() => already_have_an_access_code); } set { SetValue(() => already_have_an_access_code, value); } }
        public String code { get { return GetValue(() => code); } set { SetValue(() => code, value); } }
        public String new_password { get { return GetValue(() => new_password); } set { SetValue(() => new_password, value); } }
        public String confirm_new_password { get { return GetValue(() => confirm_new_password); } set { SetValue(() => confirm_new_password, value); } }
        public String confirm { get { return GetValue(() => confirm); } set { SetValue(() => confirm, value); } }
        public String need_help { get { return GetValue(() => need_help); } set { SetValue(() => need_help, value); } }
        public String loading_please_wait { get { return GetValue(() => loading_please_wait); } set { SetValue(() => loading_please_wait, value); } }
        public String no_account_found { get { return GetValue(() => no_account_found); } set { SetValue(() => no_account_found, value); } }
        public String access_code_expired { get { return GetValue(() => access_code_expired); } set { SetValue(() => access_code_expired, value); } }
        public String set_button { get { return GetValue(() => set_button); } set { SetValue(() => set_button, value); } }

        public String enter_access_code { get { return GetValue(() => enter_access_code); } set { SetValue(() => enter_access_code, value); } }

        public String invalid_access_code { get { return GetValue(() => invalid_access_code); } set { SetValue(() => invalid_access_code, value); } }
        public String server_not_responding { get { return GetValue(() => server_not_responding); } set { SetValue(() => server_not_responding, value); } }
        public String access_code_sent { get { return GetValue(() => access_code_sent); } set { SetValue(() => access_code_sent, value); } }
        public String connected_to_fb { get { return GetValue(() => connected_to_fb); } set { SetValue(() => connected_to_fb, value); } }
        public String connected_to_twitter { get { return GetValue(() => connected_to_twitter); } set { SetValue(() => connected_to_twitter, value); } }
        public String connected_to_s_health { get { return GetValue(() => connected_to_s_health); } set { SetValue(() => connected_to_s_health, value); } }
        public String shealth_qscore_desc { get { return GetValue(() => shealth_qscore_desc); } set { SetValue(() => shealth_qscore_desc, value); } }
        public String connect_shealth { get { return GetValue(() => connect_shealth); } set { SetValue(() => connect_shealth, value); } }
        public String social_registration_required_field { get { return GetValue(() => social_registration_required_field); } set { SetValue(() => social_registration_required_field, value); } }
        public String share_on_my_wall { get { return GetValue(() => share_on_my_wall); } set { SetValue(() => share_on_my_wall, value); } }
        public String quote_tweet { get { return GetValue(() => quote_tweet); } set { SetValue(() => quote_tweet, value); } }
        public String share_to_friend { get { return GetValue(() => share_to_friend); } set { SetValue(() => share_to_friend, value); } }
        public String loading_data { get { return GetValue(() => loading_data); } set { SetValue(() => loading_data, value); } }
        public String no_summary_found { get { return GetValue(() => no_summary_found); } set { SetValue(() => no_summary_found, value); } }
        public String no_phas_found { get { return GetValue(() => no_phas_found); } set { SetValue(() => no_phas_found, value); } }
        public String facebook_account_already_in_use { get { return GetValue(() => facebook_account_already_in_use); } set { SetValue(() => facebook_account_already_in_use, value); } }
        public String missing_answers { get { return GetValue(() => missing_answers); } set { SetValue(() => missing_answers, value); } }
        public String overall_q_summary { get { return GetValue(() => overall_q_summary); } set { SetValue(() => overall_q_summary, value); } }
        public String testinfgasdfsdafsdf { get { return GetValue(() => testinfgasdfsdafsdf); } set { SetValue(() => testinfgasdfsdafsdf, value); } }
        public String healthreport_intro_less_than_5 { get { return GetValue(() => healthreport_intro_less_than_5); } set { SetValue(() => healthreport_intro_less_than_5, value); } }
        public String healthreport_intro_equal_5 { get { return GetValue(() => healthreport_intro_equal_5); } set { SetValue(() => healthreport_intro_equal_5, value); } }
        public String welcome_to_health_report { get { return GetValue(() => welcome_to_health_report); } set { SetValue(() => welcome_to_health_report, value); } }
        public String your_quealth_win { get { return GetValue(() => your_quealth_win); } set { SetValue(() => your_quealth_win, value); } }
        public String your_current_health_status { get { return GetValue(() => your_current_health_status); } set { SetValue(() => your_current_health_status, value); } }
        public String your_health_risks { get { return GetValue(() => your_health_risks); } set { SetValue(() => your_health_risks, value); } }
        public String based_upon { get { return GetValue(() => based_upon); } set { SetValue(() => based_upon, value); } }
        public String hello { get { return GetValue(() => hello); } set { SetValue(() => hello, value); } }
        public String high_risk_report { get { return GetValue(() => high_risk_report); } set { SetValue(() => high_risk_report, value); } }
        public String low_risk_report { get { return GetValue(() => low_risk_report); } set { SetValue(() => low_risk_report, value); } }
        public String medium_risk_report { get { return GetValue(() => medium_risk_report); } set { SetValue(() => medium_risk_report, value); } }
        public String health_coach_content_report { get { return GetValue(() => health_coach_content_report); } set { SetValue(() => health_coach_content_report, value); } }
        public String your_health_coach { get { return GetValue(() => your_health_coach); } set { SetValue(() => your_health_coach, value); } }
        public String gp_text { get { return GetValue(() => gp_text); } set { SetValue(() => gp_text, value); } }
        public String app_quote { get { return GetValue(() => app_quote); } set { SetValue(() => app_quote, value); } }
        public String signup_account { get { return GetValue(() => signup_account); } set { SetValue(() => signup_account, value); } }
        public String signup_account_with { get { return GetValue(() => signup_account_with); } set { SetValue(() => signup_account_with, value); } }
        public String we_need_more_detail { get { return GetValue(() => we_need_more_detail); } set { SetValue(() => we_need_more_detail, value); } }
        public String log_in_with { get { return GetValue(() => log_in_with); } set { SetValue(() => log_in_with, value); } }
        public String change_name { get { return GetValue(() => change_name); } set { SetValue(() => change_name, value); } }
        public String update_name { get { return GetValue(() => update_name); } set { SetValue(() => update_name, value); } }
        public String change_email { get { return GetValue(() => change_email); } set { SetValue(() => change_email, value); } }
        public String update_email { get { return GetValue(() => update_email); } set { SetValue(() => update_email, value); } }
        public String current_password { get { return GetValue(() => current_password); } set { SetValue(() => current_password, value); } }
        public String update_password { get { return GetValue(() => update_password); } set { SetValue(() => update_password, value); } }
        public String tutorials { get { return GetValue(() => tutorials); } set { SetValue(() => tutorials, value); } }
        public String de_activate_account { get { return GetValue(() => de_activate_account); } set { SetValue(() => de_activate_account, value); } }
        public String registration_intro { get { return GetValue(() => registration_intro); } set { SetValue(() => registration_intro, value); } }
        public String quealth_summary { get { return GetValue(() => quealth_summary); } set { SetValue(() => quealth_summary, value); } }
        public String view { get { return GetValue(() => view); } set { SetValue(() => view, value); } }
        public string support { get { return GetValue(() => support); } set { SetValue(() => support, value); } }
        public String email_cant_change { get { return GetValue(() => email_cant_change); } set { SetValue(() => email_cant_change, value); } }
        public String Also_available_on { get { return GetValue(() => Also_available_on); } set { SetValue(() => Also_available_on, value); } }
        public String Refresh { get { return GetValue(() => Refresh); } set { SetValue(() => Refresh, value); } }
        public String coach_summary { get { return GetValue(() => coach_summary); } set { SetValue(() => coach_summary, value); } }



        public String hra_tutorial_windows { get { return GetValue(() => hra_tutorial_windows); } set { SetValue(() => hra_tutorial_windows, value); } }
        public String off_menu_tutorial_windows { get { return GetValue(() => off_menu_tutorial_windows); } set { SetValue(() => off_menu_tutorial_windows, value); } }
        public String timeline_tutorial_windows { get { return GetValue(() => timeline_tutorial_windows); } set { SetValue(() => timeline_tutorial_windows, value); } }
        public String share_tutorial_windows { get { return GetValue(() => share_tutorial_windows); } set { SetValue(() => share_tutorial_windows, value); } }
        public String view_update_tutorial { get { return GetValue(() => view_update_tutorial); } set { SetValue(() => view_update_tutorial, value); } }
        public String insights_tutorial_windows { get { return GetValue(() => insights_tutorial_windows); } set { SetValue(() => insights_tutorial_windows, value); } }
        public String score_tutorial_windows { get { return GetValue(() => score_tutorial_windows); } set { SetValue(() => score_tutorial_windows, value); } }
        public String overall_qscore_tutorial_windows { get { return GetValue(() => overall_qscore_tutorial_windows); } set { SetValue(() => overall_qscore_tutorial_windows, value); } }
        public String advice_tutorial_windows { get { return GetValue(() => advice_tutorial_windows); } set { SetValue(() => advice_tutorial_windows, value); } }
        public String advice_detail_tutorial_windows { get { return GetValue(() => advice_detail_tutorial_windows); } set { SetValue(() => advice_detail_tutorial_windows, value); } }
        public String insights_bar_tutorial_windows { get { return GetValue(() => insights_bar_tutorial_windows); } set { SetValue(() => insights_bar_tutorial_windows, value); } }
        public String score_windows { get { return GetValue(() => score_windows); } set { SetValue(() => score_windows, value); } }
        public String dashboard_tutorial_windows { get { return GetValue(() => dashboard_tutorial_windows); } set { SetValue(() => dashboard_tutorial_windows, value); } }

        public String Advicepanel_tutorials_windows { get { return GetValue(() => Advicepanel_tutorials_windows); } set { SetValue(() => Advicepanel_tutorials_windows, value); } }

        public String go_tutorial_windows { get { return GetValue(() => go_tutorial_windows); } set { SetValue(() => go_tutorial_windows, value); } }
        public String current { get { return GetValue(() => current); } set { SetValue(() => current, value); } }
        public String expand_pha_tutorial_windows { get { return GetValue(() => expand_pha_tutorial_windows); } set { SetValue(() => expand_pha_tutorial_windows, value); } }
        public String foqpha_tutorial_windows { get { return GetValue(() => foqpha_tutorial_windows); } set { SetValue(() => foqpha_tutorial_windows, value); } }
        public String questionnaire_tutorial_windows { get { return GetValue(() => questionnaire_tutorial_windows); } set { SetValue(() => questionnaire_tutorial_windows, value); } }

        public String cant_update_same_name { get { return GetValue(() => cant_update_same_name); } set { SetValue(() => cant_update_same_name, value); } }
        public String your_personalised_health_report { get { return GetValue(() => your_personalised_health_report); } set { SetValue(() => your_personalised_health_report, value); } }
        public String health_report_content { get { return GetValue(() => health_report_content); } set { SetValue(() => health_report_content, value); } }
        public String health_report_well_done { get { return GetValue(() => health_report_well_done); } set { SetValue(() => health_report_well_done, value); } }
        public String email_my_report { get { return GetValue(() => email_my_report); } set { SetValue(() => email_my_report, value); } }
        public String health_report { get { return GetValue(() => health_report); } set { SetValue(() => health_report, value); } }
        public String health_report_tutorial_windows { get { return GetValue(() => health_report_tutorial_windows); } set { SetValue(() => health_report_tutorial_windows, value); } }
        public String create_healthplan { get { return GetValue(() => create_healthplan); } set { SetValue(() => create_healthplan, value); } }
        public String manage_healthplan { get { return GetValue(() => manage_healthplan); } set { SetValue(() => manage_healthplan, value); } }
        public String health_today { get { return GetValue(() => health_today); } set { SetValue(() => health_today, value); } }
        public String time_build_new_you { get { return GetValue(() => time_build_new_you); } set { SetValue(() => time_build_new_you, value); } }
        public String health_plan_help { get { return GetValue(() => health_plan_help); } set { SetValue(() => health_plan_help, value); } }
        public String okay { get { return GetValue(() => okay); } set { SetValue(() => okay, value); } }
        public String targets { get { return GetValue(() => targets); } set { SetValue(() => targets, value); } }
        public String strategies { get { return GetValue(() => strategies); } set { SetValue(() => strategies, value); } }
        public String objective_set { get { return GetValue(() => objective_set); } set { SetValue(() => objective_set, value); } }
        public String by_doing { get { return GetValue(() => by_doing); } set { SetValue(() => by_doing, value); } }

        public String Target_tutorial_win { get { return GetValue(() => Target_tutorial_win); } set { SetValue(() => Target_tutorial_win, value); } }
        public String Create_healthplan_tutorial_win { get { return GetValue(() => Create_healthplan_tutorial_win); } set { SetValue(() => Create_healthplan_tutorial_win, value); } }
        public String Objective_selection_tutorial_win { get { return GetValue(() => Objective_selection_tutorial_win); } set { SetValue(() => Objective_selection_tutorial_win, value); } }
        public String Strategy_tutorial_win { get { return GetValue(() => Strategy_tutorial_win); } set { SetValue(() => Strategy_tutorial_win, value); } }
        public String Custom_strategy_tutorial_win { get { return GetValue(() => Custom_strategy_tutorial_win); } set { SetValue(() => Custom_strategy_tutorial_win, value); } }
        public String Edit_strategy_tutorial_win { get { return GetValue(() => Edit_strategy_tutorial_win); } set { SetValue(() => Edit_strategy_tutorial_win, value); } }
        public String Set_objective_tutorial_win { get { return GetValue(() => Set_objective_tutorial_win); } set { SetValue(() => Set_objective_tutorial_win, value); } }

        public string health_report_sent_successfully { get { return GetValue(() => health_report_sent_successfully); } set { SetValue(() => health_report_sent_successfully, value); } }

        public string Email_validation_sociallogin { get { return GetValue(() => Email_validation_sociallogin); } set { SetValue(() => Email_validation_sociallogin, value); } }

      
        public string assessments { get { return GetValue(() => assessments); } set { SetValue(() => assessments, value); } }
        public string assessments_description { get { return GetValue(() => assessments_description); } set { SetValue(() => assessments_description, value); } }
        public string plan { get { return GetValue(() => plan); } set { SetValue(() => plan, value); } }
        public string plan_description { get { return GetValue(() => plan_description); } set { SetValue(() => plan_description, value); } }
        public string coach { get { return GetValue(() => coach); } set { SetValue(() => coach, value); } }
        public string coach_description { get { return GetValue(() => coach_description); } set { SetValue(() => coach_description, value); } }
        public string score_description { get { return GetValue(() => coach_description); } set { SetValue(() => coach_description, value); } }
        public string why_quealth { get { return GetValue(() => why_quealth); } set { SetValue(() => why_quealth, value); } }
        public string why_quealth_description { get { return GetValue(() => why_quealth_description); } set { SetValue(() => why_quealth_description, value); } }
        public string introducing { get { return GetValue(() => introducing); } set { SetValue(() => introducing, value); } }
        public string swipe_to_begin { get { return GetValue(() => swipe_to_begin); } set { SetValue(() => swipe_to_begin, value); } }       
        public string skip { get { return GetValue(() => skip); } set { SetValue(() => skip, value); } }
        public string tackling_big_five { get { return GetValue(() => tackling_big_five); } set { SetValue(() => tackling_big_five, value); } }
        public string loading { get { return GetValue(() => loading); } set { SetValue(() => loading, value); } }
        public string get_started { get { return GetValue(() => get_started); } set { SetValue(() => get_started, value); } }
        public string already_account { get { return GetValue(() => already_account); } set { SetValue(() => already_account, value); } }
        public string terms_privacy_header { get { return GetValue(() => terms_privacy_header); } set { SetValue(() => terms_privacy_header, value); } }
        public string wlcm_quealth_coach { get { return GetValue(() => wlcm_quealth_coach); } set { SetValue(() => wlcm_quealth_coach, value); } }
        public string sign_up_ { get { return GetValue(() => sign_up_); } set { SetValue(() => sign_up_, value); } }
        public string create_my_account { get { return GetValue(() => create_my_account); } set { SetValue(() => create_my_account, value); } }
        public string sign_up_with { get { return GetValue(() => sign_up_with); } set { SetValue(() => sign_up_with, value); } }
        public string or_with_email { get { return GetValue(() => or_with_email); } set { SetValue(() => or_with_email, value); } }
        public string contact_you_by_e_means { get { return GetValue(() => contact_you_by_e_means); } set { SetValue(() => contact_you_by_e_means, value); } }
        public string disclose_personal_data { get { return GetValue(() => disclose_personal_data); } set { SetValue(() => disclose_personal_data, value); } }
        public string tell_us_more_about_you { get { return GetValue(() => tell_us_more_about_you); } set { SetValue(() => tell_us_more_about_you, value); } }
        public string birthday { get { return GetValue(() => birthday); } set { SetValue(() => birthday, value); } }
        public string female { get { return GetValue(() => female); } set { SetValue(() => female, value); } }
        public string ok_let_go { get { return GetValue(() => ok_let_go); } set { SetValue(() => ok_let_go, value); } }
        public string your_motivation { get { return GetValue(() => your_motivation); } set { SetValue(() => your_motivation, value); } }
        public string motivation_assessment { get { return GetValue(() => motivation_assessment); } set { SetValue(() => motivation_assessment, value); } }
        public string home { get { return GetValue(() => home); } set { SetValue(() => home, value); } }
        public string more { get { return GetValue(() => more); } set { SetValue(() => more, value); } }
        public string motivation { get { return GetValue(() => motivation); } set { SetValue(() => motivation, value); } }
        public string please_select_gender { get { return GetValue(() => please_select_gender); } set { SetValue(() => please_select_gender, value); } }
        public string please_select_dob { get { return GetValue(() => please_select_dob); } set { SetValue(() => please_select_dob, value); } }
        public string what_would_you_like { get { return GetValue(() => what_would_you_like); } set { SetValue(() => what_would_you_like, value); } }
        public string health_plan_welcome { get { return GetValue(() => health_plan_welcome); } set { SetValue(() => health_plan_welcome, value); } }
        public string health_agenda_footer { get { return GetValue(() => health_agenda_footer); } set { SetValue(() => health_agenda_footer, value); } }
        public string health_agendaheader { get { return GetValue(() => health_agendaheader); } set { SetValue(() => health_agendaheader, value); } }

        public string your_lifestyle_assessments { get { return GetValue(() => your_lifestyle_assessments); } set { SetValue(() => your_lifestyle_assessments, value); } }

        public string your_lifestyle_assessment_content { get { return GetValue(() => your_lifestyle_assessment_content); } set { SetValue(() => your_lifestyle_assessment_content, value); } }








        protected new T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);
            var storedValue = base.GetValue<T>(propertyName);
            if (string.IsNullOrEmpty(storedValue as string))
            {
                if (_variableCache.ContainsKey(propertyName))
                    return (T)_variableCache[propertyName];
            }
            return storedValue;
        }


        Dictionary<string, object> _variableCache = new Dictionary<string, object> {

{"health_agenda_footer","Health Coach will be checking in with you shortly - keep an eye on the Coaching area of the Home Screen for new messages. In the meantime, enjoy taking a look around Quealth and making a start on some of those next steps!"},
{"health_agendaheader","The Health Agenda’s all about setting the scene - understanding your motivations and key health risks so that we identify your optimum pathway through Quealth. Here’s what we understand about you so far." },
{"health_plan_welcome", "SELECT UP TO FIVE OBJECTIVES BELOW"},
{"what_would_you_like", "What would you like to do today?"},
{"no_summary_found", "No summary found"},
{"targets", "Targets"},
{"strategies", "Strategies"},
{"ethanol_grammes", "grammes (Ethanol) / week"},
{"and", "and"},
{"optimum_q", "Optimum Q"},
{"send_me_temprary_password", "Send me a temporary password"},
{"please_enter_value", "Please enter a value"},
{"help", "Help"},
{"name_must_be_of_two_characters", "Name field must contain at least 2 characters."},
{"please_select_country", "Please select Health guidelines"},
{"enter_confirm_new_password", "Please confirm your new password."},
{"validation_select_dob", "Please select your date of birth"},
{"non_smoker", "Non-smoker"},
{"never_measured", "Never measured"},
{"non_drinker", "Non-drinker"},
{"intake_high", "High intake"},
{"intake_moderate", "Moderate intake"},
{"intake_healthy", "Healthy intake"},
{"total_cholestorl", "Total cholesterol"},
{"g_l", "g/L"},
{"forgotten_password", "Forgotten password?"},
{"request_an_access_code", "Request an access code"},
{"already_have_an_access_code", "Already have an access code?"},
{"confirm_new_password", "Confirm new password"},
{"need_help", "Need Help?"},
{"account", "Account"},
{"server_not_responding", "Server not responding."},
{"connected_to_s_health", "Connected to S Health"},
{"shealth_qscore_desc", "Quealth monitors your health using biometrics and vital signs using S Health."},
{"social_registration_required_field", "Please fill in below details to complete the registration process."},
{"loading_data", "Loading data..."},
{"no_phas_found", "No pha's data found."},
{"intake_low", "Low intake"},
{"set_button", "Set"},
{"enter_old_password", "Please enter your current password."},
{"high_risk", "HIGH RISK PRIORITIES"},
{"back_to_q", "Back to My Q"},
{"blood_glucose", "Blood glucose"},
{"bmi", "Body mass index"},
{"calculate", "Calculate"},
{"centimetres", "Centimetres"},
{"yes", "Yes"},
{"cm", "cm"},
{"cm_word", "cm"},
{"compare", "Compare"},
{"confirm_password", "Confirm Password"},
{"go", "Go"},
{"code", "Code"},
{"confirm", "Confirm"},
{"loading_please_wait", "Loading graphic"},
{"no_account_found", "No account found with this email address."},
{"access_code_sent", "Your access code has been sent to your registered email address."},
{"connected_to_fb", "Connected to Facebook"},
{"connected_to_twitter", "Connected to Twitter"},
{"connect_shealth", "Connect to S Health"},
{"share_on_my_wall", "Share on my wall"},
{"quote_tweet", "Quote tweet"},
{"share_to_friend", "Share to friends"},
{"facebook_account_already_in_use", "The Facebook account you tried to connect with is already associated with a Quealth account."},
{"missing_email", "Please enter your email address."},
{"policy_long", "Privacy policy"},
{"invalid_login", "The email address or password you have entered is incorrect."},
{"valid_email", "Please enter a valid email address."},
{"missing_answer", "Please answer the question."},
{"missing_option", "Please select an option."},
{"invalid_date_entry", "Please enter a valid date."},
{"invalid_email_entry", "Please enter a valid email address."},
{"month_oct", "Oct"},
{"month_sep", "Sep"},
{"month_nov", "Nov"},
{"month_dec", "Dec"},
{"date_rd", "rd"},
{"date_nd", "nd"},
{"date_st", "st"},
{"risk_assessment", "Risk Assessment"},
{"met_mins", "MET-mins per week"},
{"refined_carbs", "Refined carbohydrate"},
{"risk_head_you", "You"},
{"healthy_fats", "Healthy fats"},
{"smoking", "Smoking"},
{"low_risk", "LOW RISK PRIORITIES"},
{"risk_head_yours", "Your risk"},
{"high_fibre", "Fibre"},
{"smoking_status", "Smoking status"},
{"male", "Male"},
{"feet", "ft"},
{"total", "Total"},
{"systolic", "Systolic"},
{"mg_dl", "mg/dL"},
{"high_risk_ethnicity", "High risk ethnicity"},
{"low", "Low"},
{"high", "High"},
{"devices_services", "Devices/Services"},
{"change_details", "Change Details"},
{"cigs_per_day", "cigarettes per day"},
{"twitter_account_already_in_use", "The Twitter account you tried to connect with is already associated with a Quealth account."},
{"inches_word", "inches"},
{"close_action", "Close"},
{"continue", "Continue"},
{"current_q_score", "Your Q is currently {{total_Health Q}}"},
{"dashboard", "Dashboard"},
{"invite_a_friend", "Invite a friend"},
{"send", "Send"},
{"share_with_fb", "Share with Facebook"},
{"connect_to_s_health", "Connect to S Health"},
{"connect_to_twitter", "Connect to Twitter"},
{"feedback_message", "Thank you! We would love to hear from you"},
{"cancel", "Cancel"},
{"please_select_an_option", "Please select an option"},
{"login_with_twitter", "Login with Twitter"},
{"forgot_your_password", "Forgot password?"},
{"almost_there", "Almost there!"},
{"signup_with_fb", "Signup with Facebook"},
{"signup_with_twitter", "Signup with Twitter"},
{"health_guidelines", "Health guidelines"},
{"current_q", "Current Q"},
{"temp_password_request", "Temporary password request"},
{"please_enter_name", "Please enter your name."},
{"please_enter_valid_name", "Your name can't contain numbers or special characters."},
{"please_enter_password", "Please enter a password."},
{"please_enter_confirm_password", "Please confirm your password."},
{"minimum_password_length_message", "Your password needs to have a minimum of 6 characters with at least one number or special character."},
{"please_select_language", "Please select Language"},
{"user_not_exist", "User does not exist"},
{"enter_new_password", "Please enter a new password."},
{"enter_dob", "Please enter your date of birth"},
{"settings_password_mismatched", "Passwords do not match."},
{"overall_q_summary", "Overall Health Q"},
{"missing_answers", "We’ve added some new questions so if you return to the Dashboard & redo the questionnaires you’ll be able to make sure your Q is as accurate as possible."},
{"q_score", "Health Q"},
{"same_password_found", "You have previously used this password, Please choose a different one."},
{"new_password", "New password"},
{"occasional_drinker", "Occasional drinker"},
{"intake_zero", "Zero intake"},
{"signin_help", "Signin help"},
{"invalid_access_code", "You have entered an invalid access code."},
{"welcome_message", "Hello.<br>Ready?"},
{"year_old_women", "year old women"},
{"risk_head_neutral", "Your risk neutral"},
{"disclaimer", "By Signing up, you agree to Roadtohealth Group’s"},
{"high_strap", "These are significantly increasing your health risk"},
{"medium_risk", "MEDIUM RISK PRIORITIES"},
{"email", "Email"},
{"password_mismatched", "Password does not match."},
{"low_strap", "These are actually reducing your health risk - keep it up!"},
{"date_th", "th"},
{"today", "Today"},
{"log_in", "Log in"},
{"sign_up", "Sign Up"},
{"password", "Password"},
{"risk_factors", "Risk Factors"},
{"version", "Version"},
{"full_name", "Name"},
{"terms_long", "Terms and conditions"},
{"health_plan", "Health Plan"},
{"m_cm", "m/cm"},
{"ft_inches", "ft/inches"},
{"kg", "kg"},
{"st_lb", "st/lb"},
{"lb", "lb"},
{"mmol_l", "mmol/L"},
{"month_jan", "Jan"},
{"month_feb", "Feb"},
{"month_apr", "Apr"},
{"month_mar", "Mar"},
{"language", "Language"},
{"update_details", "Update details"},
{"score", "Score"},
{"prev_button", "Prev"},
{"feedback", "Feedback"},
{"your", "Your"},
{"optimum", "Optimum"},
{"peer_average", "Peer average"},
{"your_dashboard", "Your dashboard"},
{"men", "Men"},
{"women", "Women"},
{"year_old_men", "year old men"},
{"men_whole", "Men as a whole"},
{"women_whole", "Women as a whole"},
{"prevalence", "Prevalence"},
{"waist_girth", "Waist girth"},
{"physical_activity", "Physical activity"},
{"next_button", "Next"},
{"insights", "Insights"},
{"healthy_zone", "Healthy Zone"},
{"transition_zone", "Transition Zone"},
{"high_risk_zone", "High Risk Zone"},
{"number_0", "0"},
{"view_insights", "View Insights"},
{"see_insights", "See Insights"},
{"now", "Now"},
{"learn_more", "Learn more"},
{"optimal", "Optimal"},
{"terms", "Terms"},
{"policies", "Policies"},
{"settings", "Settings"},
{"login", "Login"},
{"logout", "Logout"},
{"general", "General"},
{"name", "Name"},
{"update_results", "Update your results"},
{"high_fibre_intake", "Intake of high-fibre foods"},
{"refined_carbs_intake", "Intake of refined carbohydrates"},
{"healthy_fat_intake", "Intake of healthy fats"},
{"month_may", "May"},
{"month_jun", "Jun"},
{"month_jul", "Jul"},
{"month_aug", "Aug"},
{"mmhg", "mmHg"},
{"hdl", "HDL"},
      {"inches", "\""},
{"m", "m"},
{"st", "st"},
{"decimal_place", "."},
{"unknown", "Unknown"},
{"normal", "Normal"},
{"stress_high", "High stress"},
{"stress_moderate", "Moderate stress"},
{"stress_low", "Low stress"},
{"moderate", "Moderate"},
{"about", "About"},
{"alcohol_units", "unit(s) per week"},
{"alert", "Alert"},
{"diastolic", "Diastolic"},
{"cto_compare", "Check out how you compare against others of your age and sex"},
{"friends_of_q", "Friends of Quealth"},
{"share_with_friends", "Share with your friends"},
{"share_with_contacts", "Share with contacts"},
{"no_devices_are_currently_connected", "No devices are currently connected!"},
{"connect_your_device", "Connect your device"},
{"connect_to_Social", "Connect to social"},
{"current", "Current"},
{"connect_to_Fb", "Connect to Facebook"},
{"proceed", "Proceed"},
{"please_enter_your_answer", "Please enter a value"},
{"login_with_facebook", "Login with Facebook"},
{"dont_have_account", "Don't have an account"},
{"or", "or"},
{"overview", "Overview"},
{"not_connected", "You don't appear to be connected to the internet, please check your connection and try again."},
{"medium_strap", "These are affecting your health risk to some degree"},
{"dashboard_hp_tutorial", "Tap here to create your Health Plan"},
{"view", "View"},
{"mtwh", "Make the world healthier"},
{"my_q_score", "My Q"},
{"share_with_twitter", "Share with Twitter"},
{"legal", "Legal"},
{"warning", "Warning"},
{"hra_warning_message", "Are you sure you want to navigate away from this page? All your progress will be lost."},
{"no", "No"},
{"mmhg10", "mmHg/10"},
{"hra_tutorial", "Tap on any of these to start an assessment"},
{"off_menu_tutorial", "Tap here to explore other areas of Quealth"},
{"overflow_tutorial", "Tap here to change language"},
{"timeline_tutorial", "Check this area for updates from the Quealth coach"},
{"hra_summary_close_tutorials", "Tap on the icon again to return to the Dashboard"},
{"go_tutorial", "Start assessment"},
{"view_update_tutorial", "View or update your results"},
{"swipe_left_to_insight_tutorial", "Swipe left to see your insights"},
{"swipe_right_to_result_tutorial", "Swipe right to see your results"},
{"result_bottom_arrow_tutorial", "Tap right here for your in-depth results"},
{"swipe_left_to_dashboard_tutorial", "Swipe left to get back to the dashboard"},
{"arrow_tutorial", "If you can see one of these then swipe the text down for more"},
{"help_tutorial", "Tricky question? Tap here if we're not making ourselves clear"},
{"de_activate_account", "Deactivate account"},
{"overall_qscore_tutorial", "This is your overall Quealth score tap on it to find out more"},
{"insight_bar_tutorial", "Swipe or tap to see how you shape up against others in different health areas"},
{"swipe_right_to_dashboard_tutorial", "Swipe right to get back to the dashboard"},
{"pha_top_arrow_tutorial", "Tap here to get back to the results table"},
{"health_area_tutorial", "Tap on a health area for your results and personal advice"},
{"more_tutorial", "Want to find out more?\ntap on this expand button"},
{"kart_tutorial", "We may have something that interests you - tap here to find out more"},
{"on", "ON"},
{"log_in_for", "Log in for"},
{"off", "OFF"},
{"tutorials", "Tutorials"},
{"signup_account", "Sign Up account"},
{"app_quote", "Unlocking life's potential"},
{"log_in_with", "Log in with"},
{"signup_account_with", "Sign Up with"},
{"registration_intro", "We're all about protecting your health - but also your personal details. That's why registration  is necessary to keep all your information safe and secure."},
{"we_need_more_detail", "We just need a few more details"},
{"deactivation_other_option", "Other, please explain further:"},
{"coach_summary", "Your physical, mental and emotional health is your most treasured possession - and now it's truly in your hands.\n<br /><br />\nYou're just a few minutes away from finding out how healthy you really are - so just tap on any one of the five Quealth icons to start your journey of discovery.\n<br /><br />\n<b>Don't be in the dark about your health - let Quealth turn impossible into I'm possible.</b>"},
{"skip_que_tutorial", "Tap on any of the above sections to skip forward or back"},
{"redo_hra_tutorial", "We've made some improvements! Tap on any of these icons to update your answers and refresh your Q."},
{"pha_overview_tutorial", "Tap to learn more about your overall health"},
{"password_must_contain_numbers_and_special_char", "Your password should contain a minimum of 6 characters with at least one number or special character."},
{"wrong_old_password", "You have incorrectly entered your current password."},
{"access_code_expired", "Your access code has expired, Please request a new one."},
{"token_expired_message", "Logged in session expired. Please login again."},
{"email_cant_change", "Email can't be changed when using your Social Log in."},
{"manage_health_plan", "Manage Health Plan"},
{"create_health_plan", "Create Health Plan"},
{"social_login_no_email_change", "Email can't be changed when using a social log in"},
{"social_login_no_password_change", "Password can't be changed when using a social log in"},
{"current_password", "Current Password"},
{"change_name", "Change name"},
{"update_name", "Update name"},
{"update_email", "Update email"},
{"change_email", "Change email"},
{"update_password", "Update password"},
{"health_report", "Health Report"},
      {"health_report_content", @"<font color='#19b1a4'><h4>What's in your Health Report?</h4>This and that etc and emotinal health is your most treasured possession - and now it's truly in your hands. <ul><li>You're just a few minutes away</li><li>From finding out how healthy</li><li>You really are - so just tap on any.</li></ul>Tell the user when they will receive their report."},
{"email_my_report", "Email my report"},
{"your_personalised_health_report", "Your Personalised Health Report"},
{"health_report_well_done", "Well done for starting your  health journey with Quealth!"},
{"pdf_tutorial", "Tap here to request your Health Report"},
{"your_health_coach", "your Quealth coach"},
{"your_quealth", "Your Quealth"},
{"your_health_risks", "Your health risks"},
{"your_current_health_status", "Your current health status"},
{"medium_risk_report", "Medium Risk"},
{"low_risk_report", "Low Risk"},
{"high_risk_report", "High Risk"},
{"hello", "Hello"},
{"health_coach_content_report", "<strong>Quealth</strong> - a coming together of your genetics, lifestyle and environment to create the energy, vitality and\nwellbeing that makes you the person you are - today and for your future.<br /><br />\nThe higher your Quealth, the healthier you are - and we’re here to help you with every step towards\nachieving your personal potential.<br /><br />\n<strong>Strive for progress, not perfection</strong> - just be better than yesterday and make the rest of your life the best of your life!<br /><br />\n<strong>With you all the way,</strong>"},
{"based_upon", "Based upon completing the following assessments :"},
{"healthreport_intro_equal_5", "Here’s your latest Quealth Report, summarising your Quealth score[x>1[s]] and health priorities for the [no_of_q_word] health assessment[x>1[s]] you’ve completed [x<5[so far]].<br /><br />\nYou’ve now covered all five of the most disruptive health conditions in the developed world and should have\na full understanding of your overall health status as well as exactly what you can do to maximise your\npersonal health and wellbeing.<br /><br />\nThese diseases are all very different from each other in how they affect us but there is one thing they have in\ncommon - <strong>they are all driven significantly by the lifestyles we choose to lead on a daily basis.</strong><br /><br />\nPhysical inactivity, poor diet, smoking and excessive alcohol consumption all dramatically increase health\nrisk but at the same time, keeping these areas of lifestyle in check will significantly improve all aspects of\nhealth, wellbeing and vitality.\n<br /><br /><strong>Your health is a journey - and Quealth is with you every step of the way!</strong>"},
{"healthreport_intro_less_than_5", "Here’s your latest Quealth Report, summarising your Quealth score[x>1[s]] and health priorities for the [no_of_q_word] health assessment[x>1[s]] you’ve completed [x<5[so far]].<br /><br />\nWe recommend that you [x<4[build up]] [x==4[complete]] your Quealth profile by completing the\n[uncompleted_hra] assessment[!x>1[s]] -\nthis will provide an even richer understanding of your health status and how to improve your personal health\nand wellbeing.<br /><br />\nThe five diseases that Quealth assesses are all very different from each other in how they affect us but there\nis one thing they have in common - <b>they are all driven significantly by the lifestyles we choose to lead\non a daily basis.</b><br /><br />\nPhysical inactivity, poor diet, smoking and excessive alcohol consumption all dramatically increase health\nrisk but at the same time, keeping these areas of lifestyle in check will significantly improve all aspects of\nhealth, wellbeing and vitality.\n<br /><br /><strong>Your health is a journey - and Quealth is with you every step of the way!</strong>"},
{"okay", "Okay"},
{"time_build_new_you", "start your journey here by selecting up to five health objectives!"},
{"tutorial_target", "Tap on any of these to set target"},
{"tutorial_healthplan_help", "Not making ourselves clear, tap here"},
{"tutorial_healthplan_objective", "Choose up to five objectives from any section"},
{"by_doing", "By doing?"},
{"tutorial_strategy", "Have your own strategy?<br>Tap here to add it"},
{"tutorial_strategy_set", "Tap here to set your objective"},
{"tap_to_add_strategy", "Add your own strategy"},
{"support", "Support"},
{"health_plan_help", "<!DOCTYPE html>\n<html>\n<body>\n\n<b>Your personal health sat nav - where do you want to take your health today?</b> <br/> <br/> Welcome to Health Plan - where you’ll be able to very quickly and easily simplify your wide-ranging health assessment results into a focussed, practical plan that details specifically what you want to achieve and how you’re going to achieve it - <b>in three easy steps!<br/><br/>Step 1 - select your health objectives</b><br/>You can select up to five different health objectives across a range of six different health areas.<br/><br/><b>Step 2 - select a target for each objective</b><br/> Remember to keep it achievable and heading nicely towards the health levels described in your health assessment results<br/><br/><b>Step 3 - select a range of strategies to help you achieve your objective</b><br/>You can select as many of these as you like as well as create your own - ether way, they should be realistic and suit your current lifestyle.<br/><br/>You can view the details of your set objectives by tapping on the + icons displayed next to them on the main menu and you can of course review and update them whenever you want.<br/><br/><b>Good luck and remember - measure achievement not by perfection but by progress!</b>\n\n</body>\n</html>"},
{"welcome_to_health_report", "Welcome to your <strong>Health Report</strong>"},
{"update_hras", "Time to update!"},
{"share_tutorial", "Tap here to share with your friends or followers"},
{"view_our_help", "View our support information, create a ticket or manage your existing tickets"},
{"quealth_summary", "Quealth Summary"},
{"enter_access_code", "Please enter your access code."},
{"gp_text", "<h3>We recommend that you check in with your doctor</h3><br/><p>Sometimes it’s a good idea to check in with your doctor to make them aware of any results that are sufficiently outside of the healthy range so they can assess and advise you further as they see fit. </p><p>It’s quite possible that your doctor won’t be overly concerned about your results and will simply support the lifestyle advice that we are providing you. They may however feel that closer monitoring and management may be necessary and it’s for this reason that we recommend you make contact with them.</p><p> Your doctor may of course already be aware of why we’re referring you so if you feel that this is already ‘in hand’ and that there is no need to see them then feel free to take no further action - although you may still wish to make them aware of your results for their records.</p>"},
{"your_quealth_win", "Your Quealth"},
{"Also_available_on", "Also available on:"},

{"hra_tutorial_windows", "Click on any of these to start an assessment"},
{"off_menu_tutorial_windows", "Click here to explore other areas of Quealth"},
{"timeline_tutorial_windows", "Check this area for updates from the Quealth coach"},
{"share_tutorial_windows", "Click here to share with your friends or followers"},
{"view_update_tutorial ", "View or Update Tutorial"},
{"insights_tutorial_windows", "Click here to see your Insights"},
{"score_tutorial_windows", "Click here to see your Results"},
{"overall_qscore_tutorial_windows", "This is your overall Quealth score. Click on it to find out more"},
{"Refresh", "Refresh"},
{"advice_tutorial_windows", "Click here to visit your Advice page"},
{"advice_detail_tutorial_windows", "Click on the view button for any health area to see your results and personal advice"},
{"insights_bar_tutorial_windows", "Click here to see how you shape up against others in different health areas"},
{"dashboard_tutorial_windows", "Click here to get back to Dashboard"},
{"score_windows", "Score"},
{"Advicepanel_tutorials_windows", "Click on any health area for your results and personal advice" },
{"go_tutorial_windows","Start assessment" },
{"expand_pha_tutorial_windows","Click on this expand button" },
{"foqpha_tutorial_windows","We may have something that interests you - tap here to find out more" },
{"questionnaire_tutorial_windows","Click on any of the above sections to skip forward or back" },
{"cant_update_same_name","Can not update same name" },
{"health_report_tutorial_windows","Click here to see your health report" },
{"create_healthplan", "Create Health Plan"},
{"manage_healthplan", "Manage Health Plan"},
{"health_today", "Where do you want to take your health today?"},
{"Create_healthplan_tutorial_win","Click here to create your health plan" },
{"Objective_selection_tutorial_win","Choose unto five objectives from any section" },
{"Target_tutorial_win","Click on any of these to set target" },
{"Custom_strategy_tutorial_win","Have your own strategy? Click here to add it" },
{"Set_objective_tutorial_win","Click here to set your objective" },
{"health_report_sent_successfully","Your latest Quealth Report is on it's way and will be in your email inbox within the next ten minutes" },
{"Edit_strategy_tutorial_win", "Click here to edit your strategy"},
{ "Strategy_tutorial_win" , "Click here to choose your strategy"},
{ "Email_validation_sociallogin","Email and Password can’t be changed when using social login" },
{"why_quealth", "Why Quealth" },
{"why_quealth_description","Health is our most valuable human asset.So we created Quealth to help you achieve your health potential. Here’s how we’re going to do it…" },
{"assessments", "Assessments" },
{"assessments_description", "Understand your key health risks and what you can do to improve them." },
{"plan", "Plan" },
{ "plan_description", "Your personal health and life style action plan." },
{ "coach", "Coach" },
{ "coach_description", "Your personal health coach. All the support and guidance you need, every step of the way." },
{"score_description", "Governed by an active, on going program of formal clinical validation."},
{"introducing"  , "Introducing"},
{"swipe_to_begin"   , "Governed by an active, ongoing program of formal clinical validation."},
{"skip" , "Skip"},
{"tackling_big_five"    , "Tackling the Big Five"},
{"loading"  , "Loading"},
{"get_started"  , "Get started"},
{"already_account"  , "Already have an account?"},
{"terms_privacy_header" , "Terms of Use and Privacy Policy"},
{"wlcm_quealth_coach"   , "Welcome to Quealth Coach"},
{"sign_up_" , "Sign Up"},
{"create_my_account"    , "Create my account"},
{"sign_up_with" , "Sign Up with"},
{"or_with_email"    , "or with email"},
{"contact_you_by_e_means"   , "Swipe here if you would like us to contact you by electronic means (email or SMS) with information about goods and services which we feel may be of interest to you."},
{"disclose_personal_data"   , "Swipe here if you do not want us to disclose your personal data to carefully selected Friends of Quealth partners so they can provide you with information about their goods or services."},
{"tell_us_more_about_you"   , "Tell us more about you"},
{"birthday" , "birthday"},
{"ok_let_go"    , "Ok let's go"},
{"your_motivation"  , "Your Motivation"},
{"motivation_assessment"    , "Motivation assessment"},
{"home" , "Home"},
{"more" , "More"},
{"female" , "female"},
{"motivation"   , "Motivation"},
{"please_select_gender" , "Please select gender"},
{"please_select_dob"    , "Please select Date of Birth"},
{"your_lifestyle_assessments" , "Your Lifestyle Assessments"},
{"your_lifestyle_assessment_content"    , "Your Lifestyle Assessment Content"},


   };
    }




    public class Variables
    {
        public int status { get; set; }
        public string message { get; set; }
        public Variable data { get; set; }
    }
}
