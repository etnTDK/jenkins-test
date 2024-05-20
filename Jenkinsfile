pipeline {
   agent any

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
