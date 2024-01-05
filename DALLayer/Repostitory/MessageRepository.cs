using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Repostitory
{
    public class MessageRepository
    {
        private ClinicalDbContext _context;
        public MessageRepository() 
        {
            _context = new ClinicalDbContext();
        }
        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public Message GetMessageById(int messageId)
        {
            return _context.Messages.Find(messageId);
        }

        public IEnumerable<Message> GetById(int id)
        {
            IEnumerable<Message> messages = _context.Messages.
               OrderByDescending(mess => mess.MessageTime).
               Where(mess => mess.ReceiverId == id || mess.SenderId == id);
            return messages;
        }
        public IEnumerable<Message> GetBySenderIdAndRecieverId(int SenderId, int RecieverId)
        {
            IEnumerable<Message> messages = _context.Messages.
                OrderBy(mess => mess.MessageTime).
                                   //from doctor to patient                                   //from patient to doctor
                Where(mess => (mess.ReceiverId == RecieverId && mess.SenderId == SenderId) || (mess.ReceiverId == SenderId && mess.SenderId == RecieverId));
            return messages;
        }  //select * from messages where senderid=SenderId and reciverid=RecieverId
        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
            Save();
        }
  
        public void UpdateMessage(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            Save();
        }

        public void DeleteMessage(int messageId)
        {
            var message = _context.Messages.Find(messageId);
            _context.Messages.Remove(message);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
