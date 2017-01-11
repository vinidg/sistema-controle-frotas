using NAppUpdate.Framework.FeedReaders;
using NAppUpdate.Framework.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinAppUpdate
{
    public class DummyReader : IUpdateFeedReader
    {
        public IList<IUpdateTask> Read(string feed)
        {
            return new List<IUpdateTask>
			{
				new LengthyTask {Description = "Isso aqui faz nada so manda mensagem de atualizacao"},
				new LengthyTask {Description = "Isso aqui é pra mostrar que a mensagem rola na tela"},
                new LengthyTask {Description = "Só pra ter certeza que vai rolar na tela"}
			};
        }
    }
}
