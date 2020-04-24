namespace RecordMaker.Infrastructure.Validators
{
    public class ErrorMessages
    {
        public static string PasswordEmpty => "empty_password";
        public static string PasswordLength => "invalid_length";
        public static string PasswordUppercaseLetter => "must_have_upper_letter";
        public static string PasswordLowercaseLetter => "must_have_lower_letter";
        public static string PasswordDigit => "must_have_digit";
        public static string PasswordSpecialCharacter => "must_have_special_character";
    }
}