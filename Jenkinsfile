pipeline {
   agent any
   environment {
              DISABLE_AUTH = 'true'
              DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
   }
    stages {
        stage('Build') {
            
             agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                }
            }
            steps {
                echo 'Building  ...'
                sh '''
                    ls -la
                    dotnet --version
                    dotnet clean
                    dotnet build
                    ls -la
                '''
            }
        }
    }
}
