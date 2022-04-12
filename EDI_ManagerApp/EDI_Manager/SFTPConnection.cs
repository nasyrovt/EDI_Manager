using WinSCP;

namespace EDI_Manager
{
    public class SFTPConnection
    {
        public int ConnectionTest()
        {
            try
            {
                // Setup session options
                WinSCP.SessionOptions sessionOptions = new WinSCP.SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = "192.168.0.25",
                    UserName = "user",
                    Password = "password",
                    PortNumber = 22,
                    SshHostKeyFingerprint = "ssh-rsa 2048 tQKxJE9axobCC4WSJkk9JWqq+8AxtbcvgOQz553kgCs"
                };

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    if (session.Opened)
                        Console.WriteLine("Session is opened successfully");
                    else
                        Console.WriteLine("Error openning session");

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    transferResult =
                                    session.PutFiles(@"d:\toupload\*", "/home/user/", false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    }
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
                return 1;
            }
        }
    }
}
