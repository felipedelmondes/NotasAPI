using NotasApp.BLL.DTO;
using NotasApp.BLL.Interfaces.Repository;
using NotasApp.BLL.Interfaces.Services;
using NotasApp.BLL.ViewModels;

namespace NotasApp.BLL.Services;

public class NotasServices : INotasServices
{
    private readonly INotasRepository _notasRepository;

    public NotasServices(INotasRepository notasRepository)
    {
        _notasRepository = notasRepository;
    }

    public List<NotasDTO> GetAll()
    {
        return _notasRepository.getAll();
    }

    public NotaViewModel getById(int id)
    {
        return _notasRepository.getById(id);
    }

    public string addnota(NotaViewModel nota)
    {
        return _notasRepository.addNota(nota);
    }

    public string updatenota(int notaId, NotaViewModel nota)
    {
        return _notasRepository.updateNota(notaId, nota);
    }

    public string deleteNota(int notaId)
    {
        return _notasRepository.deleteNota(notaId);
    }
}