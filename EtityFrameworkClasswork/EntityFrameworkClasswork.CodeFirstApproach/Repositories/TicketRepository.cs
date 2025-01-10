using EntityFramework_classwork.Data;
using EntityFramework_classwork.Models;

namespace EntityFrameworkClasswork.CodeFirstApproach.Repositories;

public class TicketRepository
{
    TrainsDbContext trainsDbContext = new TrainsDbContext();
    
    // READ
    public List<Ticket> GetTickets()
    {
        return trainsDbContext.Tickets.ToList();
    }
    
    // READ BY ID
    public Ticket GetTicketById(int id)
    {
        return trainsDbContext.Tickets.Where(x => x.Id == id).FirstOrDefault();
    }
    
    // CREATE
    public void CreateTicket(Ticket ticket)
    {
        trainsDbContext.Tickets.Add(ticket);
        
        trainsDbContext.SaveChangesAsync();
    }
    
    // UPDATE
    public void UpdateTicket(Ticket newTicket)
    {
        trainsDbContext.Tickets.Update(newTicket);
    }
    
    // DELETE
    public void DeleteTicket(Ticket ticket)
    {
        trainsDbContext.Tickets.Remove(ticket);
    }
    
    // DELETE BY ID
    public void DeleteTicket(int id)
    {
        trainsDbContext.Tickets.Remove(GetTicketById(id));
    }
}