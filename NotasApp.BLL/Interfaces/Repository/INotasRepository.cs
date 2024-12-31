using System.Reflection.Metadata.Ecma335;
using NotasApp.BLL.DTO;
using NotasApp.BLL.ViewModels;

namespace NotasApp.BLL.Interfaces.Repository;

public interface INotasRepository
{
    public List<NotasDTO> getAll();
    public NotaViewModel getById(int id);
    public string addNota(NotaViewModel nota);
    public string updateNota(int notaId, NotaViewModel nota);
    public string deleteNota(int notaId);
}