import 'package:flutter/material.dart';
import 'package:Front_Flutter/pages/register/register_controllers.dart';
import 'package:Front_Flutter/pages/home/home.dart';

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
  String? _erreurMessage;
  bool _isLoading = false;

  void _handleRegister() async{
    final username = _usernameController.text;
    final email = _emailController.text;
    final password = _passwordController.text;
    final confirmPassword = _confirmPasswordController.text;

    if (username.isEmpty || email.isEmpty || password.isEmpty || confirmPassword.isEmpty){
      setState(() {
        _erreurMessage = 'Veuillez remplir tout les champs !';
      });
      return;
    }

    if (password != confirmPassword){
      setState(() {
        _erreurMessage = 'Veuillez renseignez deux mot de passe identique !';
      });
      return;
    }

    setLoading(true);

    final message = await RegisterController.register(username, email, password);

    setLoading(false);
    setState(() {
      _erreurMessage = message;
    });

    if (message == 'Utilisateur ajouté avec succès !'){
      setLoading(true); // Active le chargement
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

  void setLoading(bool value){
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
                _buildTextField('Identifiant', controller: _usernameController),
                const SizedBox(height: 15),
                _buildTextField('Adresse e-mail', controller: _emailController),
                const SizedBox(height: 15),
                _buildTextField('Mot de passe', controller: _passwordController, obscureText: true),
                const SizedBox(height: 15),
                _buildTextField('Mot de passe Vérif', controller: _confirmPasswordController, obscureText: true),
                const SizedBox(height: 25),
                _buildRegisterButton(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  AppBar _buildAppBar() {
    return AppBar(
      automaticallyImplyLeading: false,
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
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          TextField(
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
          if(hintText == 'Mot de passe Vérif' && _erreurMessage != null && _erreurMessage != 'Utilisateur ajouté avec succès !')
            Padding(
                padding: const EdgeInsets.only(top: 5),
              child: Text(
                _erreurMessage!,
                style: const TextStyle(
                  color: Colors.red,
                  fontSize: 12,
                ),
              ),
            )
        ],
      )
    );
  }

  Widget _buildRegisterButton() {
    return SizedBox(
      width: 200,
      child: ElevatedButton(
        onPressed: () {
          _handleRegister();
        },
        child: const Text('Créer un compte'),
      ),
    );
  }
}
