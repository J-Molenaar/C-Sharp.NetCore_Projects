using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace Wall
{
    public static class Queries{
    

        public static List<Dictionary<string, object>> Message()
        {
        return DbConnector.Query("SELECT messages.message, users.id AS user_id, messages.id, messages.active, CONCAT(users.first_name, ' ', users.last_name) AS name, DATE_FORMAT(messages.created_at, '%M %D, %Y - %h:%m%p') AS created_at FROM messages JOIN users ON messages.user_id = users.id ORDER BY messages.created_at DESC;");

        }
        public static List<Dictionary<string, object>> Comments()
        {
        return DbConnector.Query("SELECT comments.comment, comments.message_id, CONCAT(users.first_name, ' ', users.last_name) AS name, comments.created_at FROM comments JOIN users ON comments.user_id = users.id JOIN messages ON comments.message_id = messages.id");

        }
    }
}
