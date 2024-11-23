pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        script {
          sh('dotnet build')
        }
      }
    }
    stage('Deploy to Staging') {
      steps {
        script {
          sh('docker-compose up --build -d')
        }
      }
    }
  }
}
