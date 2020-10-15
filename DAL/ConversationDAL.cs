using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConversationDAL
    {
        VCDbContext _context = new VCDbContext();
        public IEnumerable<Conversation> GetConversations(string sender, string receiver)
        {
            return _context.Conversations.Where(c => (c.Sender == sender && c.Receiver == receiver) ||
                                            (c.Sender == receiver && c.Receiver == sender))
                                            .OrderByDescending(c => c.AddedOn).ToList();
        }

        public ApiResponse AddMessage(Conversation conversation)
        {
            try
            {
                conversation.AddedOn = DateTime.Now;
                _context.Conversations.Add(conversation);
                _context.SaveChanges();
                return new ApiResponse
                {
                    Added = true,
                    Message = "Conversation added successfully."
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    Added = false,
                    Message = "Error occured. Please try again..."
                };
            }
        }
    }
}
