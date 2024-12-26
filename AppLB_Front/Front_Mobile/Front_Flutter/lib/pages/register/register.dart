import 'package:flutter/material.dart';

class RegisterPage extends StatefulWidget {
  const RegisterPage({super.key});

  @override
  State<RegisterPage> createState() => _RegisterPageState();
}

class _RegisterPageState extends State<RegisterPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController = TextEditingController();

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
            const SizedBox(height: 15),
            _buildTextField('Adresse e-mail :', controller: _emailController),
            const SizedBox(height: 15),
            _buildTextField('Mot de passe :', controller: _passwordController, obscureText: true),
            const SizedBox(height: 15),
            _buildTextField('Mot de passe :', controller: _confirmPasswordController, obscureText: true),
            const SizedBox(height: 25),
            _buildRegisterButton(),
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
      'Créer un compte',
      style: TextStyle(
        fontSize: 30,
        fontWeight: FontWeight.bold,
        color: Colors.white,
      ),
    );
  }

  Widget _buildTextField(String hintText, {required TextEditingController controller, bool obscureText = false}) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25),
      child: TextField(
        controller: controller,
        obscureText: obscureText,
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

  Widget _buildRegisterButton() {
    return SizedBox(
      width: 200,
      child: ElevatedButton(
        onPressed: () {
          print('Créer un compte cliqué');
        },
        child: const Text('Créer un compte'),
      ),
    );
  }
}
