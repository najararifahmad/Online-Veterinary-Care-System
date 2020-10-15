using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ConversationBAL
    {
        ConversationDAL _dal = new ConversationDAL();

        public IEnumerable<Conversation> GetConversations(string sender, string receiver)
        {
            return _dal.GetConversations(sender, receiver);
        }

        public ApiResponse AddMessage(Conversation conversation)
        {
            return _dal.AddMessage(conversation);
        }
    }
}
