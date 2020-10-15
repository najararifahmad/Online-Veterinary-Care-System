using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConversationHistoryDAL
    {
        VCDbContext _context = new VCDbContext();
        public IEnumerable<ConversationHistory> GetConversationHistories(string name)
        {

            return _context.ConversationHistories.Where(c => c.Sender == name ||
                                                        c.Receiver == name)
                                                        .OrderByDescending(c => c.AddedOn).ToList();
        }

        public ApiResponse AddConversationHistory(string sender, string receiver, string message)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var conversationHistory = _context.ConversationHistories.Where(c => (c.Sender == sender
                                                                                         && c.Receiver == receiver) ||
                                                                                         (c.Sender == receiver 
                                                                                         && c.Receiver == sender))
                                                                            .FirstOrDefault();
                    if (conversationHistory != null)
                    {
                        _context.ConversationHistories.Remove(conversationHistory);
                        _context.SaveChanges();
                    }
                    _context.ConversationHistories.Add(new ConversationHistory
                    {
                        Sender = sender,
                        Receiver = receiver,
                        Message = message,
                        AddedOn = DateTime.Now
                    });
                    _context.SaveChanges();
                    transaction.Commit();
                    return new ApiResponse
                    {
                        Added = true,
                        Message = "Conversation History saved successfully."
                    };
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return new ApiResponse
                    {
                        Added = false,
                        Message = "Error occured. Please try again..."
                    };
                }
            }
        }
    }
}
