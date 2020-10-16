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
                                            .OrderBy(c => c.AddedOn).ToList();
        }

        public ApiResponse AddMessage(Conversation conversation)
        {
            try
            {
                ConversationHistoryDAL _dal = new ConversationHistoryDAL();

                conversation.AddedOn = DateTime.Now;
                _context.Conversations.Add(conversation);
                _context.SaveChanges();

                _dal.AddConversationHistory(conversation.Sender, conversation.Receiver, conversation.Message);
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
