using Dapper;
using NotasApp.BLL.DTO;
using NotasApp.BLL.Interfaces.Repository;
using NotasApp.BLL.ViewModels;
using NotasApp.DAL.Context;

namespace NotasApp.DAL.Repository;

public class NotasRepository : INotasRepository
{
    private readonly DBContext _context;

    public NotasRepository(DBContext context)
    {
        _context = context;
    }

    public List<NotasDTO> getAll()
    {
        var notas = new List<NotasDTO>();
        var query = @" select n.id_note ,n.titulo,n.conteudo, n.data_registro from notas n ";

        try
        {
            using (var conn = _context.CreateConnection())
            {
                var result = conn.Query<NotasDTO>(query);
                
                foreach (var lista in result)
                {
                    notas.Add(lista);
                }
            }

            return notas;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public NotaViewModel getById(int id)
    {
        var nota = new NotaViewModel();
        var query = $@" select 
                        n.titulo ,
                        n.conteudo 
                        from notas n 
                        where n.id_note = {id}";

        try
        {
            using (var conn = _context.CreateConnection())
            {
                nota = conn.Query<NotaViewModel>(query).FirstOrDefault();
            }

            return nota;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public string addNota(NotaViewModel nota)
    {
        var notaAdd = new NotasDTO()
        {
            Conteudo = nota.Conteudo
        };

        var query = @$" insert into notas(conteudo) values('{nota.Conteudo}') ";
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var result = conn.ExecuteScalar<string>(query, notaAdd);
            }

            return "Nota cadastrada com sucesso";
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public string updateNota(int notaId, NotaViewModel nota)
    {
        var query = String.Empty;
        
        if (!string.IsNullOrWhiteSpace(nota.Conteudo) && !string.IsNullOrWhiteSpace(nota.Titulo))
        {
            query = @$"update notas set titulo = '{nota.Titulo}', conteudo = '{nota.Conteudo}' where id_note = {notaId}";
        }

        if (!string.IsNullOrWhiteSpace(nota.Conteudo) && string.IsNullOrWhiteSpace(nota.Titulo))
        {
            query = @$"update notas set conteudo = '{nota.Conteudo}' where id_note = {notaId}";
        }

        if (!string.IsNullOrWhiteSpace(nota.Titulo) && string.IsNullOrWhiteSpace(nota.Conteudo))
        {
            query = @$"update notas set titulo = '{nota.Titulo}' where id_note = {notaId}";
        }

        try
        {
            using (var conn = _context.CreateConnection())
            {
                var result = conn.ExecuteScalar<string>(query);
            }

            return "Nota alterada com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string deleteNota(int notaId)
    {
        var query = $"delete from notas where id_note = {notaId} ";
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var result = conn.ExecuteScalar<string>(query);
            }

            return "Nota excluida com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}