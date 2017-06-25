using System;

namespace Aurochses.Testing
{
    /// <summary>
    /// Class EmailHelpers.
    /// </summary>
    public static class EmailHelpers
    {
        /// <summary>
        /// Creates the test email address based on Type FullName.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="localPart">The localPart. Local part is account name or user name of mail box.</param>
        /// <param name="domain">The domain.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Email length must be less than 256 characters.</exception>
        /// <example>{localPart}+{type.FullName}+{name}@{domain}</example>
        public static string Create(Type type, string name, string localPart = "test", string domain = "aurochses.com")
        {
            var email = $"{localPart}+{type.FullName}+{name}@{domain}";

            if (email.Length > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(email), email, "Email length must be less than 256 characters.");
            }

            return email;
        }
    }
}