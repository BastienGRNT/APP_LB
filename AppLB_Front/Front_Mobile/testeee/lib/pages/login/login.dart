import 'package:flutter/material.dart';
import 'package:testeee/pages/login/login_controllers.dart';


class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  void _handleLogin() async {
    final username = _usernameController.text;
    final password = _passwordController.text;

    final message = await LoginController.login(username, password);

    //TODO : Renvoyer erreur pour les champs vide

    //TODO : Faire affichier l'erreur afficher par l'API en dessous du texteField mot de passe

    print(message);
    print('Username: $username');
    print('Password: $password');

    if (message == 'Mot de passe correct !'){
      print('CACA');
      //TODO : Redirection vers page d'acceuil !
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF0C134F),
      appBar: _buildAppBar(),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            _buildTitle(),
            const SizedBox(height: 30),
            _buildTextField('Identifiant :', controller: _usernameController),
            const SizedBox(height: 10),
            _buildTextField('Mot de passe :', controller: _passwordController),
            _buildLoginButton(),
            const SizedBox(height: 30),
            _buildFooter(),
          ],
        ),
      ),
    );
  }

  AppBar _buildAppBar() {
    return AppBar(
      backgroundColor: const Color(0xFF5C469C),
      title: const Text(
        'Cezizi',
        style: TextStyle(
          fontSize: 45,
          fontWeight: FontWeight.bold,
          color: Colors.white,
        ),
      ),
      toolbarHeight: 100,
      centerTitle: true,
      shape: const RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(
          bottom: Radius.circular(60),
        ),
      ),
    );
  }

  Widget _buildTitle() {
    return const Text(
      'Se connecter !!!',
      style: TextStyle(
        fontSize: 30,
        fontWeight: FontWeight.bold,
        color: Colors.white,
      ),
    );
  }

  Widget _buildTextField(String hintText, {required TextEditingController controller}) {
    return Container(
      width: 300,
      child: TextField(
        controller: controller,
        obscureText: hintText == 'Mot de passe :', // Masque le texte pour le mot de passe
        decoration: InputDecoration(
          hintText: hintText,
          filled: true,
          fillColor: Colors.white,
          border: OutlineInputBorder(
            borderRadius: BorderRadius.circular(20),
          ),
        ),
      ),
    );
  }

  Widget _buildLoginButton() {
    return Container(
      margin: const EdgeInsets.all(20),
      width: 200,
      child: ElevatedButton(
        onPressed: _handleLogin,
        child: const Text('Se connecter'),
      ),
    );
  }

  Widget _buildFooter() {
    return Column(
      children: [
        const Text(
          "Vous n'avez pas de compte :",
          style: TextStyle(
            fontSize: 15,
            color: Colors.white,
            fontWeight: FontWeight.bold,
          ),
        ),
        TextButton(
          onPressed: () {
            print('Créer un compte !');
          },
          child: const Text(
            'Créer un compte !',
            style: TextStyle(
              color: Colors.white,
              decoration: TextDecoration.underline,
            ),
          ),
        ),
      ],
    );
  }
}
