import 'dart:convert';
import 'package:http/http.dart' as http;

class RegisterController {
  static const String apiUrl = 'http://192.168.1.15:5125/api/Controller_Register';

  static Future<String> register(String username, String email, String password) async {
    try{
      final reponse = await http.post(
        Uri.parse(apiUrl),
        headers: {
          'Content-Type': 'application/json',
        },
        body:
          jsonEncode({
            'user_id': username,
            'user_mail': email,
            'user_password': password,
          }),
      );

      if(reponse.statusCode == 200){
        final data = json.decode(reponse.body);
        return data['message'] ?? 'Register réussie';
      } else {
        final errorData = json.decode(reponse.body);
        return errorData['error'] ?? 'Erreur inconnue';
      }
    }catch(e){
      return 'erreur resea : $e';
    }

  }

}
