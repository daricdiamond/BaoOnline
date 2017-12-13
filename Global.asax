<%@ Application Language="C#" %>

<script RunAt="server">

    System.Timers.Timer timer = new System.Timers.Timer(1000);
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        timer.Start();
    }
    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (DateTime.Now.Hour == 1)
        {
            // Làm gì đó 
        }
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session.Timeout = 2880;
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
