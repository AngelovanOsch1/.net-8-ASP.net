namespace WebAPIDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequiredClaimAttribute: Attribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; }

        public RequiredClaimAttribute(string claimType, string claimValue)
        {
            this.ClaimType = claimType;
            this.ClaimValue = claimValue;
        }
    }
}
