pipeline {
   agent {
      docker {
         image 'mcr.microsoft.com/dotnet/sdk:8.0'
         reuseNode true
         args '-u root:root' // Dùng khi bị lỗi permission 
      }
   } 
   /*
   // Hoặc dùng cái này khi bị lỗi permission 
   environment {
      DISABLE_AUTH = 'true'
      DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
   }*/
    stages {
       stage('Restore package') {
            steps {
                sh '''
                    dotnet restore
                    echo "Restored done!"
                '''
            }
        }
        stage('Clean') {
            steps {
                sh '''
                    dotnet clean
                    echo "Cleaned done!"
                '''
            }
        }
        stage('Build') {
            steps {
                sh '''
                    ls -la
                    dotnet --version
                    dotnet clean
                    dotnet build
                    ls -la
                    echo "Built done!"
                '''
            }
        }
        stage('Test') {
            steps {
                sh '''
                    dotnet test --logger "trx;LogFileName=UnitTestResults.trx"
                    echo "Test done!"
                '''
            }
        }
       stage('Deploy') {
            steps {
                   def remote = [:]
                   remote.name = 'test'
                   remote.host = 'test.domain.com'
                   remote.user = 'root'
                   remote.password = 'password'
                   remote.allowAnyHosts = true
            }
        }
    }
   
}
