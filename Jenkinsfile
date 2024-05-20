pipeline {
   agent {
      docker {
         image 'mcr.microsoft.com/dotnet/sdk:8.0'
      }
   } 
   environment {
      DISABLE_AUTH = 'true'
      DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
   }
    stages {
        stage('Build') {
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
        stage('Test') {
            steps {
                echo 'Testing  ...'
                sh '''
                    dotnet test
                '''
            }
        }
    }
}
