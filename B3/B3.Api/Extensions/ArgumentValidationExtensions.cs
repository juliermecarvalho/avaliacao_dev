namespace B3.Api.Extensions
{
    public static class ArgumentValidationExtensions
    {
        /// <summary>
        /// Verifica se o argumento é maior que zero. Lança uma exceção se não for.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="paramName">O nome do parâmetro para exibir na exceção.</param>
        public static void ThrowIfNotGreaterThanZero(decimal value, string? paramName = null)
        {
            paramName ??= nameof(value);
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "O valor deve ser maior que 0.");
            }
        }

        /// <summary>
        /// Verifica se o argumento é maior que um. Lança uma exceção se não for.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="paramName">O nome do parâmetro para exibir na exceção.</param>
        public static void ThrowIfNotGreaterThanOne(decimal value, string? paramName = null)
        {
            paramName ??= nameof(value);
            if (value <= 1)
            {
                throw new ArgumentOutOfRangeException(paramName, "O valor deve ser maior que 1.");
            }
        }
    }
}