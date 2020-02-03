namespace Application.Common.Models
{
    public class SignInResult
    {
        public static SignInResult Failed { get; }
        public static SignInResult LockedOut { get; }
        public static SignInResult NotAllowed { get; }
        public static SignInResult Success { get; }
        public static SignInResult TwoFactorRequired { get; }
        public bool IsLockedOut { get; protected set; }
        public bool IsNotAllowed { get; protected set; }
        public bool RequiresTwoFactor { get; protected set; }
        public bool Succeeded { get; protected set; }
    }
}