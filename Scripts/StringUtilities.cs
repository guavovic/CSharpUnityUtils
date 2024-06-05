namespace GV.Extensions
{
    public static class StringUtilities
    {
        /// <summary>
        /// Este m�todo tem como objetivo formatar um nome de campo.
        /// Primeiro, ele substitui todos os underscores ("_") no nome do campo por espa�os em branco.
        /// Em seguida, utiliza uma express�o regular para encontrar qualquer letra mai�scula que n�o esteja no in�cio da string (usando a sequ�ncia de escape "\B") e adiciona um espa�o antes dela.
        ///
        /// Por exemplo, se o nome do campo for "nome_do_campo", o m�todo retornar� "Nome do Campo".
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
