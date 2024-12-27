import 'package:Front_Flutter/pages/register/register.dart';
import 'package:flutter/material.dart';
import 'package:Front_Flutter/pages/login/login_controllers.dart';
import 'package:Front_Flutter/pages/home/home.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  String? _errorMessage;
  bool _isLoading = false;

  void _handleLogin() async {
    final username = _usernameController.text;
    final password = _passwordController.text;

    if (username.isEmpty || password.isEmpty) {
      setState(() {
        _errorMessage = 'Veuillez remplir tous les champs';
      });
      return;
    }

    setLoading(true);

    final message = await LoginController.login(username, password);

    setLoading(false);
    setState(() {
      _errorMessage = message;
    });

    setState(() {
      _errorMessage = message;
    });

    if (message == 'Mot de passe correct !') {
      setLoading(true);
      await Future.delayed(const Duration(seconds: 2));
      setLoading(false);
      if(mounted){
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => const HomePage()),
        );
      }
    }
  }

  void setLoading(bool value) {
    setState(() {
      _isLoading = value;
    });
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF0C134F),
      appBar: _buildAppBar(),
      body: Center(
        child: _isLoading
            ? const CircularProgressIndicator()
            : SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                _buildTitle(),
                const SizedBox(height: 30),
                _buildTextField('Identifiant :', controller: _usernameController),
                const SizedBox(height: 10),
                _buildTextField('Mot de passe :', controller: _passwordController),
                const SizedBox(height: 20),
                _buildLoginButton(),
                const SizedBox(height: 30),
                _buildFooter(),
              ],
            ),
          ),
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
      'Se connecter',
      style: TextStyle(
        fontSize: 30,
        fontWeight: FontWeight.bold,
        color: Colors.white,
      ),
    );
  }

  Widget _buildTextField(String hintText, {required TextEditingController controller}) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          TextField(
            controller: controller,
            obscureText: hintText == 'Mot de passe :',
            decoration: InputDecoration(
              hintText: hintText,
              filled: true,
              fillColor: Colors.white,
              border: OutlineInputBorder(
                borderRadius: BorderRadius.circular(20),
              ),
            ),
          ),
          if (hintText == 'Mot de passe :' && _errorMessage != null && _errorMessage != 'Mot de passe correct !')
            Padding(
              padding: const EdgeInsets.only(top: 5),
              child: Text(
                _errorMessage!,
                style: const TextStyle(
                  color: Colors.red,
                  fontSize: 12,
                ),
              ),
            ),
        ],
      ),
    );
  }

  Widget _buildLoginButton() {
    return SizedBox(
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
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => const RegisterPage()),
            );
          },
          style: ButtonStyle(
            foregroundColor: WidgetStateProperty.all(Colors.white),
            textStyle: WidgetStateProperty.all(
              const TextStyle(
                decoration: TextDecoration.underline,
              ),
            ),
          ),
          child: const Text(
            'Créer un compte !', style:
            TextStyle(
              fontSize: 15,
              fontWeight: FontWeight.bold
            ),
          ),
        ),
      ],
    );
  }
}
