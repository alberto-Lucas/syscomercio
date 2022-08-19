namespace ObjetoTransferencia
{
    public sealed class UsuarioLogado
    {
        static UsuarioLogado _instancia;
        public static UsuarioLogado Instancia
        {
            get { return _instancia ?? (_instancia = new UsuarioLogado()); }
        }
        private UsuarioLogado() { }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
    }
}
