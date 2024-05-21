pipeline {
   agent {
      docker {
         image 'mcr.microsoft.com/dotnet/sdk:8.0'
         reuseNode true
      }
   } 
   environment {
      DISABLE_AUTH = 'true'
      DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
   }
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
    }
    post {
       always {
           xunit (
                    testTimeMargin: '3000',
                    thresholdMode: 1,
                    thresholds: [$class: 'FailedThreshold', unstableThreshold: '1'],
                    tools: [$class: 'MSTest', pattern: '*.trx']
                )
       }
   }
}
