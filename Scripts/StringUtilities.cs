namespace GV.Extensions
{
    public static class StringUtilities
    {
        /// <summary>
        /// Este método tem como objetivo formatar um nome de campo.
        /// Primeiro, ele substitui todos os underscores ("_") no nome do campo por espaços em branco.
        /// Em seguida, utiliza uma expressão regular para encontrar qualquer letra maiúscula que não esteja no início da string (usando a sequência de escape "\B") e adiciona um espaço antes dela.
        ///
        /// Por exemplo, se o nome do campo for "nome_do_campo", o método retornará "Nome do Campo".
        /// </summary>
        /// <param name="fieldName">O nome do campo a ser formatado.</param>
        /// <returns>O nome do campo formatado.</returns>
        public static string FormatFieldName(string fieldName)
        {
            fieldName = fieldName.Replace("_", " ");
            return System.Text.RegularExpressions.Regex.Replace(fieldName, "(\\B[A-Z])", " $1");
        }
    }
}
