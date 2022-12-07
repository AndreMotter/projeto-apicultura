using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class CodigoAcessoService : ICodigoAcessoService
    {
        private IRepositoryBase<CodigoAcesso> _repository { get; set; }

        public CodigoAcessoService(IRepositoryBase<CodigoAcesso> repository)
        {
            _repository = repository;
        }

        public string Gerar()
        {
            Random random = new Random();
            CodigoAcesso CodigoAcesso = new CodigoAcesso() 
            {
                Codigo = new string(Enumerable.Repeat("123456789", 6).Select(s => s[random.Next(s.Length)]).ToArray())
            };

            var UltimoCodigo = _repository.Query(x => x.Id == x.Id).FirstOrDefault();
            if(UltimoCodigo != null)
            {
                this.Remover(UltimoCodigo.Id);
            }
            this.Salvar(CodigoAcesso);

            //gera o arquivo TXT com o código
            this.GenerateTXTFile(CodigoAcesso.Codigo);
            return CodigoAcesso.Codigo;
        }

        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Salvar(CodigoAcesso obj)
        {
            _repository.Save(obj);
            _repository.SaveChanges();
        }

        public void GenerateTXTFile(string CodigoAcesso)
        {
            //referencia o StreamWriter, que possui os métodos pra manipular arquivos
            StreamWriter StreamWriter;

            //cita a minha pasta que vai ser gravado os códigos
            string WayFolder = $@"C:\Users\Motter\Downloads\codigos-acessos\";

            //vai deletar tudo que tiver na pasta citada acima
            this.EmptyFolder(WayFolder);

            //cria um caminho pro arquivo, gera uma Guid aleatória para identificar o mesmo
            string WayFile = $@"{WayFolder}codigo-acesso-{Guid.NewGuid()}.txt";

            //cria o arquivo no diretório citado acima
            StreamWriter = File.CreateText(WayFile);

            //vai escrever no arquivo o código de acesso que foi gerado
            StreamWriter.WriteLine(CodigoAcesso);

            //vai fechar o processo de criação do arquivo
            StreamWriter.Close();
        }

        private void EmptyFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                EmptyFolder(di.FullName);
                di.Delete();
            }
        }

    }
}
