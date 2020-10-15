using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ConversationHistoryBAL
    {
        ConversationHistoryDAL _dal = new ConversationHistoryDAL();

        public IEnumerable<ConversationHistory> GetConversationHistories(string name)
        {

            return _dal.GetConversationHistories(name);
        }

        public ApiResponse AddConversationHistory(string sender, string receiver, string message)
        {
            return _dal.AddConversationHistory(sender, receiver, message);
        }
    }
}
