using NotasApp.BLL.DTO;
using NotasApp.BLL.ViewModels;

namespace NotasApp.BLL.Interfaces.Services;

public interface INotasServices
{
    public List<NotasDTO> GetAll();
    public NotaViewModel getById(int id);
    public string addnota(NotaViewModel nota);
    public string updatenota(int notaId, NotaViewModel nota);
    public string deleteNota(int notaId);
}