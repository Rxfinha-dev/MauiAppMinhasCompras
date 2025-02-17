using SQLite; // Importa a biblioteca SQLite para manipulação de banco de dados.

namespace MauiAppMinhasCompras.Models // Define o namespace do projeto.
{
    public class Produto // Declara a classe Produto que representa um item no banco de dados.
    {
        string _descricao; // Declara um campo privado para armazenar a descrição do produto.

        [PrimaryKey, AutoIncrement] // Define que a propriedade Id será a chave primária e será auto-incrementada no banco de dados.
        public int Id { get; set; } // Propriedade pública que representa o identificador único do produto.

        public string Descricao // Propriedade pública para armazenar a descrição do produto.
        {
            get => _descricao; // Retorna o valor da descrição.
            set
            {
                if (value == null) // Verifica se o valor atribuído é nulo.
                {
                    throw new Exception(
                        "Por favor, preencha a descrição" // Lança uma exceção caso a descrição seja nula.
                    );
                }
                _descricao = value; // Atribui o valor à variável privada _descricao.
            }
        }

        public double Quantidade { get; set; } // Propriedade pública que armazena a quantidade do produto.

        public double Preco { get; set; } // Propriedade pública que armazena o preço do produto.

        public double Total { get => Quantidade * Preco; } // Propriedade somente leitura que calcula o total com base na quantidade e no preço.
    }
}
