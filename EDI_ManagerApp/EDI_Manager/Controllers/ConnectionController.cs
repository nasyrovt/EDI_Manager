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
           
            try {
                WinSCP.SessionOptions sessionOptions = CreateSessionOptions(account);

                using (Session session = new Session())
                {
                    // Connection test
                    session.Open(sessionOptions);
                    WinSCP.SshHostKeyPolicy sshHostKeyPolicy = new WinSCP.SshHostKeyPolicy();
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

        private WinSCP.SessionOptions CreateSessionOptions(FTPAccount acc)
        {
            string sshkey = "";
            Protocol protocol;
            FtpSecure security;

            try
            {
                //Getting ssh-key of current host in database
                sshkey = (from ssh in _context.SSHKeys
                          where ssh.FTPHost == acc.FTPHost
                          select ssh.Key).Single();
            }
            catch (Exception ex)
            {
                // Not valid ssh key, so server can suggest a correct one
                if (acc.FTPType == "sftp" || acc.FTPType == "scp")
                    sshkey = "ssh-rsa 2048 n0ElVFgdIZlNbjIlcHZzu+qF/KrBf/72jxtC6Yh19Rk";
                //TODO: Find solution to catch a valid key 
                else
                    sshkey = "8b:e2:c1:ff:31:ee:3b:bb:1d:2a:09:d7:05:3b:a7:44:88:5d:56:dc:b2:fd:d8:68:75:99:3d:c1:60:ef:65:4d";
            }

            switch (acc.FTPType.ToLower())
            {
                case "sftp":
                    protocol = Protocol.Sftp;
                    break;    
                case "ftps-explicit":
                    return new WinSCP.SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        FtpSecure = FtpSecure.Explicit,
                        HostName = acc.FTPHost,
                        UserName = acc.FTPUser,
                        Password = acc.FTPPassword,
                        PortNumber = acc.FTPPort,
                        TlsHostCertificateFingerprint = sshkey
                    };
                case "ftps-implicit":
                    return new WinSCP.SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        FtpSecure = FtpSecure.Implicit,
                        HostName = acc.FTPHost,
                        UserName = acc.FTPUser,
                        Password = acc.FTPPassword,
                        PortNumber = acc.FTPPort,
                        TlsHostCertificateFingerprint = sshkey
                    };
                case "scp":
                    protocol = Protocol.Scp;
                    break;
                case "s3":
                    //TODO: Check amazon-s3 connection structure
                    protocol = Protocol.S3;
                    security = FtpSecure.None;
                    break;
                case "webdav":
                    //TODO: Check if webdav needs an ssh-key
                    protocol = Protocol.Webdav;
                    security = FtpSecure.None;
                    break;
                default: // For FTP with no security
                    return new WinSCP.SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        FtpSecure = FtpSecure.None,
                        HostName = acc.FTPHost,
                        UserName = acc.FTPUser,
                        Password = acc.FTPPassword,
                        PortNumber = acc.FTPPort,
                        TlsHostCertificateFingerprint = sshkey
                    };
            }
            //Works for sftp and scp
            return new WinSCP.SessionOptions {
                Protocol = protocol,
                HostName = acc.FTPHost,
                UserName = acc.FTPUser,
                Password = acc.FTPPassword,
                PortNumber = acc.FTPPort,
                SshHostKeyFingerprint = sshkey
            };
        }
    }
}
