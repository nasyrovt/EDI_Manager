using EDI_Manager.Data;
using EDI_Manager.TableDefinitions;
using Microsoft.AspNetCore.Mvc;
using WinSCP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDI_Manager.Controllers
{
    [Route("api/connection")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly DataContext _context;

        public ConnectionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Connection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetConncetion(int id)
        {
            var account = await _context.FTPAccounts.FindAsync(id);
            string sshkey = "";

            if (account == null) { return NotFound(); }
            try
            {
                sshkey = (from ssh in _context.SSHKeys
                              where ssh.FTPHost == account.FTPHost
                              select ssh.Key).Single();
            }
            catch (Exception ex)
            {
                sshkey = "n0ElVFgdIZlNbjIlcHZzu+qF/KrBf/72jxtC6Yh19Rk";
            }
            
            
            
            try {
                WinSCP.SessionOptions sessionOptions = new WinSCP.SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = account.FTPHost,
                    UserName = account.FTPUser,
                    Password = account.FTPPassword,
                    PortNumber = account.FTPPort,
                    SshHostKeyFingerprint = "ssh-rsa 2048 " + sshkey
                };

                using (Session session = new Session())
                {
                    // Connection test
                    session.Open(sessionOptions);
                    /*
                    // Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    transferResult =
                                    session.GetFiles(@"/public/", @"E:\Courses\EDI_Manager\FilesForTesting", false, transferOptions);

                    // Throw on any error
                    transferResult.Check();*/
                }
                return "Successfully connected!";
            }
            catch(Exception e)
            {                
                return e.Message;
            }
            
        }
    }
}
